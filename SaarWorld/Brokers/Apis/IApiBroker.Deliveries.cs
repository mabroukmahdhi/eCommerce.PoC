// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;
using SaarWorld.Models.Deliveries;

namespace SaarWorld.Brokers.Apis
{
    public partial interface IApiBroker
    {
        ValueTask<Delivery> PostDeliveryAsync(Delivery delivery);
    }
}