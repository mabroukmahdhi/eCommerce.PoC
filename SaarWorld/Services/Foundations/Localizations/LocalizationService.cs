// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using SaarWorld.Brokers.Localizations;

namespace SaarWorld.Services.Foundations.Localizations
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ILocalizationBroker localizationBroker;

        public LocalizationService(ILocalizationBroker localizationBroker) =>
             this.localizationBroker = localizationBroker;

        public string this[string key] => this.localizationBroker[key];
    }
}
