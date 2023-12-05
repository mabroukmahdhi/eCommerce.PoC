// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;
using SaarWorld.Brokers.Apis;
using SaarWorld.Models.LoginRequests;
using SaarWorld.Models.LoginResponses;
using SaarWorld.Models.PasswordResetRequests;
using SaarWorld.Models.PasswordResetResponses;
using SaarWorld.Models.PasswordResetVerificationRequests;
using SaarWorld.Models.PasswordResetVerificationResponses;
using SaarWorld.Models.PasswordResetVerifiedRequests;
using SaarWorld.Models.PasswordResetVerifiedResponses;
using SaarWorld.Models.Profiles;
using SaarWorld.Models.RegisterRequests;
using SaarWorld.Models.RegisterResponses;

namespace SaarWorld.Services.Foundations.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IApiBroker apiBroker;

        public AccountService(IApiBroker apiBroker) =>
            this.apiBroker = apiBroker;

        public async ValueTask<LoginResponse> LoginAync(LoginRequest loginRequest)
        {
            var response = await this.apiBroker.PostLoginRequestAsync(loginRequest);

            this.apiBroker.SetAccessToken(response.AccessToken);

            return response;
        }

        public async ValueTask<RegisterResponse> RegisterAync(RegisterRequest registerRequest)
        {
            var response = await this.apiBroker.PostRegisterRequestAsync(registerRequest);

            this.apiBroker.SetAccessToken(response.AccessToken);

            return response;
        }

        public async ValueTask<PasswordResetResponse> PasswordResetAsync
            (PasswordResetRequest passwordResetRequest) =>
           await this.apiBroker.PostPasswordResetRequestAsync(passwordResetRequest);

        public async ValueTask<PasswordResetVerificationResponse> PasswordResetVerificationAync
          (PasswordResetVerificationRequest passwordResetVerificationRequest) =>
          await this.apiBroker.PostPasswordResetVerificationRequestAsync(passwordResetVerificationRequest);

        public async ValueTask<PasswordResetVerifiedResponse> PasswordResetVerifiedAync
          (PasswordResetVerifiedRequest passwordResetVerifiedRequest) =>
          await this.apiBroker.PostPasswordResetVerifiedRequestAsync(passwordResetVerifiedRequest);

        public async ValueTask<Profile> PutProfileSettingAync(Profile profile) =>
           await this.apiBroker.PutProfileAsync(profile);

    }
}
