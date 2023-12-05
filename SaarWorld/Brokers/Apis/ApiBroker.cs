// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Net.Http;
using System.Threading.Tasks;
using RESTFulSense.Clients;
using SaarWorld.Brokers.Preferences;
using SaarWorld.Models.Preferences;

namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker : IApiBroker
    {
        private IRESTFulApiFactoryClient apiClient;
        private HttpClient httpClient;

        public ApiBroker(HttpClient httpClient, IPreferenceBroker preferenceBroker)
        {
            var token =
                preferenceBroker.SelectPreferenceByKey(
                    key: Preference.PreferenceTokenKey);

            this.httpClient = httpClient;

            InitializeApiClient(token.Value);
        }

        private void InitializeApiClient(string token)
        {
            //if (!string.IsNullOrWhiteSpace(token))
            //{
            //    this.httpClient.DefaultRequestHeaders.Authorization =
            //        new System.Net.Http.Headers.AuthenticationHeaderValue(
            //            scheme: "Bearer",
            //            parameter: token);
            //}

            this.apiClient = new RESTFulApiFactoryClient(httpClient);
        }

        private async ValueTask<TContent> GetAsync<TContent>(string relativeUrl) =>
          await this.apiClient.GetContentAsync<TContent>(relativeUrl);

        private async ValueTask<TContent> PostAsync<TContent>(string relativeUrl, TContent content) =>
            await this.apiClient.PostContentAsync(relativeUrl, content);

        private async ValueTask<TContent> PostAsync<TContent>(string relativeUrl) =>
            await this.apiClient.PostContentAsync<TContent>(relativeUrl, default);

        private async ValueTask<TResult> PostAsync<TContent, TResult>(string relativeUrl, TContent content) =>
            await this.apiClient.PostContentAsync<TContent, TResult>(relativeUrl, content);

        private async ValueTask<TContent> PutAsync<TContent>(string relativeUrl, TContent content) =>
            await this.apiClient.PutContentAsync(relativeUrl, content);

        private async ValueTask<TResult> PutAsync<TContent, TResult>(string relativeUrl, TContent content) =>
           await this.apiClient.PutContentAsync<TContent, TResult>(relativeUrl, content);

        private async ValueTask<TContent> DeleteAsync<TContent>(string relativeUrl) =>
            await this.apiClient.DeleteContentAsync<TContent>(relativeUrl);
    }
}