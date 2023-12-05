// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

/* Unmerged change from project 'SaarWorld (net7.0-ios)'
Before:
// See License.txt in the project root for license information.
After:
// eCommerce app using information.
*/
implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using SaarWorld.Models.GeoLocations;

namespace SaarWorld.Models.Deliveries
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PackageLocation { get; set; }
        public string TargetLocation { get; set; }
        public string MoveLocation { get; set; }
        public string Shipment { get; set; }
        public string ShipmentSize { get; set; }
        public double Price { get; set; }
        public GeoLocation Distance { get; set; }
        public string State { get; set; }
    }
}
