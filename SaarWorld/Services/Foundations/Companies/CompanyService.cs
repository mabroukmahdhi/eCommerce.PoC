// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SaarWorld.Brokers.Apis;
using SaarWorld.Models.Companies;

namespace SaarWorld.Services.Foundations.Companies
{
    public partial class CompanyService : ICompanyService
    {
        private readonly IApiBroker apiBroker;
        //private readonly IMemoryCache memoryCache;
        private const string CompaniesCacheKey = "AllCompanies";
        private readonly TimeSpan cacheDuration = TimeSpan.FromMinutes(10);

        public CompanyService(
            IApiBroker apiBroker,
            IMemoryCache memoryCache)
        {
            this.apiBroker = apiBroker;
            // this.memoryCache = memoryCache;
        }

        public async ValueTask<List<Company>> GetCompaniesAsync()
        {
            //if (!memoryCache.TryGetValue(CompaniesCacheKey, out List<Company> cachedCompanies))
            //{
            //    cachedCompanies = await this.apiBroker.GetAllCompaniesAsync();

            //    var cacheEntryOptions = new MemoryCacheEntryOptions
            //    {
            //        AbsoluteExpirationRelativeToNow = cacheDuration
            //    };

            //    memoryCache.Set(CompaniesCacheKey, cachedCompanies, cacheEntryOptions);
            //}
            return await this.apiBroker.GetAllCompaniesAsync();
            //  return cachedCompanies;
        }
    }
}