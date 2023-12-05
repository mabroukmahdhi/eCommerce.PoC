// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Brokers.Apis;
using SaarWorld.Models.Cargos;
using SaarWorld.Models.Companies;
using SaarWorld.Models.Deliveries;

namespace SaarWorld.Services.Foundations.Cargoes
{
    public partial class CargoService : ICargoService
    {
        private readonly IApiBroker apiBroker;

        public CargoService(IApiBroker apiBroker) =>
            this.apiBroker = apiBroker;

        public async ValueTask<List<Cargo>> GetCargosAsync() =>
            await this.apiBroker.GetAllCargosAsync();
        public async ValueTask<List<Company>> GetCompaniesAsync() =>
            await this.apiBroker.GetAllCompaniesAsync();
        public async ValueTask<Delivery> DeliveryAsync(Delivery delivery) =>
           await this.apiBroker.PostDeliveryAsync(delivery);
        public async ValueTask<Delivery> OrderAsync() =>
            await this.apiBroker.GetOrderAsync();
    }
}