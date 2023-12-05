// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Models.Cargos;
using SaarWorld.Models.Companies;
using SaarWorld.Models.Deliveries;

namespace SaarWorld.Services.Foundations.Cargoes
{
    public partial interface ICargoService
    {
        ValueTask<List<Cargo>> GetCargosAsync();
        ValueTask<List<Company>> GetCompaniesAsync();
        ValueTask<Delivery> DeliveryAsync(Delivery delivery);
        ValueTask<Delivery> OrderAsync();
    }
}