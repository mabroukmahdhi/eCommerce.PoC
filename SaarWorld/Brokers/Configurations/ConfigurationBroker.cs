// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

namespace SaarWorld.Brokers.Configurations
{
    public class ConfigurationBroker : IConfigurationBroker
    {
        public string ApiBaseUrl => "BASE_URL_HERE";
        public string MessengingUrl => "BASE_URL_HERE/messenging";
        public string AuthenticationHeaderSchema => "bearer";
        public string RequestingUserHeader => "x-requesting-user";
    }
}