// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Models.Cargos;

namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker
    {

        private const string CargosRelativeUrl = "api/Cargos";


        public async ValueTask<List<Cargo>> GetAllCargosAsync()
        {
            return new List<Cargo>()
            {
                new Cargo
                {
                    Id = Guid.NewGuid(),
                    Name = "Truck 1",
                    Description = "Large van a favorite of couriers and delivery since the boxy shape makes it easier to deliver larger parcels or bulkier loads.",
                    ImageURl = "dotnet_bot.png",
                    Size = 100
                },
                new Cargo
                {
                    Id = Guid.NewGuid(),
                    Name = "Truck 2",
                    Description = "Large van a favorite of couriers and delivery since the boxy shape makes it easier to deliver larger parcels or bulkier loads.",
                    ImageURl = "dotnet_bot.png",
                    Size = 50
                },
                    new Cargo
                {
                    Id = Guid.NewGuid(),
                    Name = "Truck 3",
                    Description = "Large van a favorite of couriers and delivery since the boxy shape makes it easier to deliver larger parcels or bulkier loads.",
                    ImageURl = "dotnet_bot.png",
                    Size = 100
                }
            };
        }
        public async ValueTask<Cargo> GetCargoByIdAsync(Guid cargoId) =>
            await this.GetAsync<Cargo>($"{CargosRelativeUrl}/{cargoId}");

        public async ValueTask<Cargo> PutCargoAsync(Cargo cargo) =>
            await this.PutAsync(CargosRelativeUrl, cargo);

        public async ValueTask<Cargo> DeleteCargoByIdAsync(Guid cargoId) =>
            await this.DeleteAsync<Cargo>($"{CargosRelativeUrl}/{cargoId}");
        public async ValueTask<Cargo> PostCargoAsync(Cargo cargo) =>
          await this.PostAsync(CargosRelativeUrl, cargo);
    }
}