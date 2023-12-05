// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;
using SaarWorld.Models.Deliveries;
namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker
    {
        private string number = "000001";

        private const string CargoOrdersRelativeUrl = "api/CargoOrders";

        public async ValueTask<Delivery> GetOrderAsync()
        {
            int nextNumber = int.Parse(number) + 1;
            number = nextNumber.ToString("D6");
            await Task.Delay(1000);
            return new Delivery

            {
                Name = "#" + number,
                State = "Pending"
            };
        }
    }
}