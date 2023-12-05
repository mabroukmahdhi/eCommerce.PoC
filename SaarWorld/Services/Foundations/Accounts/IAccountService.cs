// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;
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
    public interface IAccountService
    {
        ValueTask<LoginResponse> LoginAync(LoginRequest loginRequest);
        ValueTask<RegisterResponse> RegisterAync(RegisterRequest registerRequest);
        ValueTask<PasswordResetResponse> PasswordResetAsync(PasswordResetRequest passwordResetRequest);
        ValueTask<PasswordResetVerificationResponse> PasswordResetVerificationAync(PasswordResetVerificationRequest passwordResetVerificationRequest);
        ValueTask<PasswordResetVerifiedResponse> PasswordResetVerifiedAync(PasswordResetVerifiedRequest passwordResetVerifiedRequest);
        ValueTask<Profile> PutProfileSettingAync(Profile profile);
    }
}