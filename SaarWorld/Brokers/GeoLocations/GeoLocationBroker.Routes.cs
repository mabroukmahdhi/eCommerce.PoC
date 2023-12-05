// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SaarWorld.Brokers.GeoLocations
{
    public partial class GeoLocationBroker
    {
        public async ValueTask<Route[]> GetRoutes(string origin, string destination)
        {
            string url = $"https://maps.googleapis.com/maps/api/directions/json?origin={origin}&destination={destination}&key={GoogleMapsApiKey}";

            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                GoogleMapsDirectionsApiResponse apiResponse = JsonConvert.DeserializeObject<GoogleMapsDirectionsApiResponse>(content);
                // Now you can use the apiResponse object to access the response data

                return apiResponse.Routes;
            }

            return default;
        }
    }

    public class GoogleMapsDirectionsApiResponse
    {
        [JsonProperty("geocoded_waypoints")]
        public GeocodedWaypoint[] GeocodedWaypoints { get; set; }

        [JsonProperty("routes")]
        public Route[] Routes { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class GeocodedWaypoint
    {
        [JsonProperty("geocoder_status")]
        public string GeocoderStatus { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }
    }

    public class Route
    {
        [JsonProperty("bounds")]
        public Bounds Bounds { get; set; }

        [JsonProperty("legs")]
        public Leg[] Legs { get; set; }

        // Other route properties...
    }

    public class Bounds
    {
        [JsonProperty("northeast")]
        public LatLng Northeast { get; set; }

        [JsonProperty("southwest")]
        public LatLng Southwest { get; set; }
    }

    public class LatLng
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public class Leg
    {
        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("end_address")]
        public string EndAddress { get; set; }

        [JsonProperty("end_location")]
        public LatLng EndLocation { get; set; }

        [JsonProperty("start_address")]
        public string StartAddress { get; set; }

        [JsonProperty("start_location")]
        public LatLng StartLocation { get; set; }

        [JsonProperty("steps")]
        public Step[] Steps { get; set; }

        // Other properties like traffic conditions, etc. can be added here
    }

    public class Distance
    {
        [JsonProperty("text")]
        public string Text { get; set; } // Example: "102 km"

        [JsonProperty("value")]
        public int Value { get; set; } // The distance in meters
    }

    public class Duration
    {
        [JsonProperty("text")]
        public string Text { get; set; } // Example: "1 hour 15 mins"

        [JsonProperty("value")]
        public int Value { get; set; } // The duration in seconds
    }

    public class Step
    {
        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("end_location")]
        public LatLng EndLocation { get; set; }

        [JsonProperty("html_instructions")]
        public string HtmlInstructions { get; set; }

        [JsonProperty("polyline")]
        public Polyline Polyline { get; set; }

        [JsonProperty("start_location")]
        public LatLng StartLocation { get; set; }

        [JsonProperty("travel_mode")]
        public string TravelMode { get; set; }

        // Other properties...
    }

    public class Polyline
    {
        [JsonProperty("points")]
        public string Points { get; set; }
    }


}