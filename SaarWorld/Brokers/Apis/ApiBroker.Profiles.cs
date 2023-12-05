// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using SaarWorld.Models.Profiles;
namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker : IApiBroker
    {
        public async ValueTask<Profile> PutProfileAsync(Profile profile)
        {
            await Task.Delay(1000);
            return new Profile
            {
                UserName = profile.UserName,
                Name = profile.Name,
                Email = profile.Email,
                Phone = profile.Phone,
                Address = profile.Address,
                AccessToken = Guid.NewGuid().ToString()

            };

        }

    }
}

