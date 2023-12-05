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
    public partial class ApiBroker
    {
        private const string CompaniesRelativeUrl = "api/Companies";

        public async ValueTask<Company> PostCompanyAsync(Company company) =>
            await this.PostAsync(CompaniesRelativeUrl, company);

        public async ValueTask<List<Company>> GetAllCompaniesAsync() =>
            await this.GetAsync<List<Company>>($"{CompaniesRelativeUrl}");

        public async ValueTask<Company> GetCompanyByIdAsync(Guid companyId) =>
            await this.GetAsync<Company>($"{CompaniesRelativeUrl}/{companyId}");

        public async ValueTask<Company> PutCompanyAsync(Company company) =>
            await this.PutAsync(CompaniesRelativeUrl, company);

        public async ValueTask<Company> DeleteCompanyByIdAsync(Guid companyId) =>
            await this.DeleteAsync<Company>($"{CompaniesRelativeUrl}/{companyId}");
    }
}