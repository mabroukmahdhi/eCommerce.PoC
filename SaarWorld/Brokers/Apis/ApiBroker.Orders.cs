// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Models.Orders;

namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker

    /* Unmerged change from project 'SaarWorld (net7.0-android)'
    Before:
        {


            private const string OrdersRelativeUrl = "api/Orders";
    After:
        {


            private const string OrdersRelativeUrl = "api/Orders";
    */
    {


        private const string OrdersRelativeUrl = "api/Orders";


        public async ValueTask<List<Order>> GetAllOrdersAsync()
        {
            await Task.Delay(1000);

            return new List<Order>()
            {
                new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "REWE",
                    Completed=true,
                    Price=200,


        },

            new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Motorcycle",
                    Completed=false,
                    Price =200,

                },
                    new Order
                {
                    Id = Guid.NewGuid(),
                    Name = "Car",
                     Price=200,
                     Completed=false,

                }
            };




        }

    }
}