// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using SaarWorld.Models.GeoLocations;

namespace SaarWorld.Models.Orders;

public class Order
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public GeoLocation Distance { get; set; }
    public Boolean Completed { get; set; }
    //public string FormattedPrice => $"${Price:F2}"; 

    public override string ToString()
    {
        return $"Price: ${Price.ToString("F2")}";
    }
}