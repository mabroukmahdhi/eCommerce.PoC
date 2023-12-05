// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

namespace SaarWorld.Services.Foundations.Localizations
{
    public interface ILocalizationService
    {
        string this[string key] { get; }
    }
}
