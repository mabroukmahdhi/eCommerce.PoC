// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;
using SaarWorld.Models.LoginRequests;
using SaarWorld.Models.LoginResponses;

namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker
    {
        private const string LoginRequestsRelativeUrl = "api/account/login";

        public async ValueTask<LoginResponse> PostLoginRequestAsync(LoginRequest loginRequest) =>
            await this.PostAsync<LoginRequest, LoginResponse>(LoginRequestsRelativeUrl, loginRequest);

        //public async ValueTask<LoginResponse> PostLoginRequestAsync(LoginRequest loginRequest)
        //{
        //    await Task.Delay(1000);

        //    return new LoginResponse
        //    {
        //        UserName = loginRequest.UserName,
        //        AccessToken = Guid.NewGuid().ToString()
        //    };
        //}
    }
}