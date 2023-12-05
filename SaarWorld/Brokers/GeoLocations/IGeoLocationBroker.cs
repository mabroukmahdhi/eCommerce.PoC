// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Models.GeoLocations;

namespace SaarWorld.Brokers.GeoLocations
{
    public interface IGeoLocationBroker
    {
        ValueTask<IEnumerable<GeoLocation>> GetGeoLocationsAsync(string address);
        ValueTask<string> ReverseGeocodeAsync(double latitude, double longitude);
        ValueTask<Route[]> GetRoutes(string origin, string destination);
    }
}