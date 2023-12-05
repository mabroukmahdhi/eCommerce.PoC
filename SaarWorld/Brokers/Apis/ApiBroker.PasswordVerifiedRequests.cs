// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using SaarWorld.Models.PasswordResetVerifiedRequests;
using SaarWorld.Models.PasswordResetVerifiedResponses;

namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker : IApiBroker
    {
        private const string PasswordResetVerifiedRequestsRelativeUrl = "api/account/passwordresetverified";

        public async ValueTask<PasswordResetVerifiedResponse> PostPasswordResetVerifiedRequestAsync(PasswordResetVerifiedRequest passwordResetVerifiedRequest)
        {
            await Task.Delay(1000);

            return new PasswordResetVerifiedResponse
            {
                AccessToken = Guid.NewGuid().ToString()

            };
        }
    }
}

