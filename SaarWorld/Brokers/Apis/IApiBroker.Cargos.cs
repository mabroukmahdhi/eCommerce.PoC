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
    public partial interface IApiBroker
    {
        ValueTask<Cargo> PostCargoAsync(Cargo cargo);
        ValueTask<List<Cargo>> GetAllCargosAsync();
        ValueTask<Cargo> GetCargoByIdAsync(Guid cargoId);
        ValueTask<Cargo> PutCargoAsync(Cargo cargo);
        ValueTask<Cargo> DeleteCargoByIdAsync(Guid cargoId);
    }
}