// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

namespace SaarWorld.Models.Messengings.Deliveries
{
    public class DeliveryToOrderInfo
    {
        public string MoveLocation { get; set; }
        public string Shipment { get; set; }
        public string ShipmentSize { get; set; }
        public string PackageLocation { get; set; }
        public string TargetLocation { get; set; }
        //public double Price { get; set; }
    }
}
