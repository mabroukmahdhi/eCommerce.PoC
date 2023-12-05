// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using RESTFulSense.Clients;

namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker
    {
        public void SetAccessToken(string accessToken) =>
             InitializeApiClient(accessToken);

        public void DeleteAccessToken()
        {
            this.httpClient.DefaultRequestHeaders.Authorization = null;
            this.apiClient = new RESTFulApiFactoryClient(httpClient);
        }
    }
}