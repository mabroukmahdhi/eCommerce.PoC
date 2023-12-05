// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using SaarWorld.Models.PasswordResetVerificationRequests;
using SaarWorld.Models.PasswordResetVerificationResponses;

namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker : IApiBroker
    {
        private const string PasswordResetVerificationRequestsRelativeUrl = "api/account/passwordresetverification";

        public async ValueTask<PasswordResetVerificationResponse> PostPasswordResetVerificationRequestAsync(PasswordResetVerificationRequest passwordResetVerificationRequest)
        {
            await Task.Delay(1000);

            return new PasswordResetVerificationResponse
            {
                AccessToken = Guid.NewGuid().ToString()

            };
        }
    }
}

