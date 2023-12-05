// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using SaarWorld.Models.PasswordResetRequests;
using SaarWorld.Models.PasswordResetResponses;

namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker : IApiBroker
    {
        private const string PasswordResetRequestsRelativeUrl = "api/account/passwordreset";
        Random aleatoire = new Random();

        public async ValueTask<PasswordResetResponse> PostPasswordResetRequestAsync(PasswordResetRequest passwordResetRequest)
        {
            await Task.Delay(1000);

            return new PasswordResetResponse
            {
                Code = aleatoire.Next()
            };
        }
    }

}

