// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using SaarWorld.Resources.Raw;

namespace SaarWorld.Brokers.Localizations
{
    public class LocalizationBroker : ILocalizationBroker
    {
        public string this[string key] =>
            SaarResources.ResourceManager.GetString(key);
    }
}
