// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;
using SaarWorld.Models.PasswordResetVerificationRequests;
using SaarWorld.Models.PasswordResetVerificationResponses;

namespace SaarWorld.Brokers.Apis
{
    public partial interface IApiBroker
    {
        ValueTask<PasswordResetVerificationResponse> PostPasswordResetVerificationRequestAsync(PasswordResetVerificationRequest passwordResetVerificationRequest);
    }
}