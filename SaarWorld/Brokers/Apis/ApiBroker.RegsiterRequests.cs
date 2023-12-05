// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using SaarWorld.Models.RegisterRequests;
using SaarWorld.Models.RegisterResponses;

namespace SaarWorld.Brokers.Apis
{

    public partial class ApiBroker
    {
        private const string RegisterRequestsRelativeUrl = "api/account/register";

        public async ValueTask<RegisterResponse> PostRegisterRequestAsync(RegisterRequest registerRequest)
        {
            await Task.Delay(1000);

            return new RegisterResponse
            {
                UserName = registerRequest.UserName,
                AccessToken = Guid.NewGuid().ToString()
            };
        }
    }
}