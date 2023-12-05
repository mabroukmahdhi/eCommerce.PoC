// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

namespace SaarWorld.Brokers.Localizations
{
    public interface ILocalizationBroker
    {
        string this[string key] { get; }
    }
}
