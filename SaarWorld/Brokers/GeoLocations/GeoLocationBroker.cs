// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

/* Unmerged change from project 'SaarWorld (net7.0-ios)'
Before:
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
After:
// See app using .NET MAUI
// ---------------------------------------------------------------
*/
implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SaarWorld.Models.GeoLocations;

namespace SaarWorld.Brokers.GeoLocations
{
    public partial class GeoLocationBroker : IGeoLocationBroker
    {
        private const string GoogleMapsApiKey = "";
        private readonly IGeocoder googleGeocoder;

        public GeoLocationBroker()
        {
            this.googleGeocoder =
                new GoogleGeocoder(
                    apiKey: GoogleMapsApiKey);
        }

        public async ValueTask<IEnumerable<GeoLocation>> GetGeoLocationsAsync(string address)
        {
            var geoAddresses = await this.googleGeocoder.GeocodeAsync(address);
            var geoLocations = new List<GeoLocation>();

            foreach (Address geoAddress in geoAddresses)
            {
                var geoLocation = new GeoLocation
                {
                    Address = geoAddress.FormattedAddress,
                    Latitude = geoAddress.Coordinates.Latitude,
                    Longitude = geoAddress.Coordinates.Longitude
                };

                geoLocations.Add(geoLocation);
            }

            return geoLocations;
        }

        private static readonly HttpClient httpClient = new HttpClient();

        public async ValueTask<string> ReverseGeocodeAsync(double latitude, double longitude)
        {
            string formattedLatitude = latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string formattedLongitude = longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

            string requestUri = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={formattedLatitude},{formattedLongitude}&key={GoogleMapsApiKey}";

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            string content = await response.Content.ReadAsStringAsync();

            GeocodingResponse result = JsonConvert.DeserializeObject<GeocodingResponse>(content);

            string address = result.Results.FirstOrDefault()?.FormattedAddress;

            return address;
        }


        public class GeocodingResponse
        {
            public class Result
            {
                [JsonProperty("formatted_address")]
                public string FormattedAddress { get; set; }
            }

            [JsonProperty("results")]
            public Result[] Results { get; set; }
        }
    }
}