// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

namespace SaarWorld.Models.GeoLocations
{
    public class GeoLocation
    {
        public GeoLocation()
        { }

        public GeoLocation(
            double latitude,
            double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}