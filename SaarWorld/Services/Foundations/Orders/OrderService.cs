// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Brokers.Apis;
using SaarWorld.Models.Orders;

namespace SaarWorld.Services.Foundations.Orders
{
    public partial class OrderService : IOrderService
    {
        private readonly IApiBroker apiBroker;

        public OrderService(IApiBroker apiBroker) =>
            this.apiBroker = apiBroker;

        public async ValueTask<List<Order>> GetOrdersAsync() =>
          await this.apiBroker.GetAllOrdersAsync();


    }
}