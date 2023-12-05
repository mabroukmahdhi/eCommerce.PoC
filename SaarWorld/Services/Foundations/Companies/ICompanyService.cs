// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Models.Companies;

namespace SaarWorld.Services.Foundations.Companies
{
    public partial interface ICompanyService
    {
        ValueTask<List<Company>> GetCompaniesAsync();
    }
}