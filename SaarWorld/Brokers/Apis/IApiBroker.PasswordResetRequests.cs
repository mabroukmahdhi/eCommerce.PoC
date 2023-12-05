// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;
using SaarWorld.Models.PasswordResetRequests;
using SaarWorld.Models.PasswordResetResponses;

namespace SaarWorld.Brokers.Apis
{
    public partial interface IApiBroker
    {
        ValueTask<PasswordResetResponse> PostPasswordResetRequestAsync(PasswordResetRequest passwordResetRequest);
    }
}