// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

namespace SaarWorld.Brokers.Configurations
{
    public interface IConfigurationBroker
    {
        string ApiBaseUrl { get; }
        string MessengingUrl { get; }
        string AuthenticationHeaderSchema { get; }
        string RequestingUserHeader { get; }
    }
}