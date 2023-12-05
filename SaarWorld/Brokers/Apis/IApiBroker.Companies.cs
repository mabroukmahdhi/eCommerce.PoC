// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Models.Companies;

namespace SaarWorld.Brokers.Apis
{
    public partial interface IApiBroker
    {
        ValueTask<Company> PostCompanyAsync(Company company);
        ValueTask<List<Company>> GetAllCompaniesAsync();
        ValueTask<Company> GetCompanyByIdAsync(Guid companyId);
        ValueTask<Company> PutCompanyAsync(Company company);
        ValueTask<Company> DeleteCompanyByIdAsync(Guid companyId);
    }
}