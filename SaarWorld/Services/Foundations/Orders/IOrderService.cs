// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Models.Orders;

namespace SaarWorld.Services.Foundations.Orders
{

    public partial interface IOrderService
    {
        ValueTask<List<Order>> GetOrdersAsync();
    }
}