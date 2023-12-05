// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using SaarWorld.Brokers.GeoLocations;

namespace SaarWorld.Services.Foundations.Localizations
{
    public partial class LocationService : ILocationService
    {
        private readonly IGeoLocationBroker geoLocationBroker;

        public LocationService(IGeoLocationBroker geoLocationBroker) =>
         this.geoLocationBroker = geoLocationBroker;

        //public async ValueTask<string> ReverseGeoLocationAsync(double latitude, double longitude) =>
        //    await this.geoLocationBroker.ReverseGeocodeAsync(latitude,longitude);

    }
}