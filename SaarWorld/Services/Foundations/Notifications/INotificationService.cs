// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Models.Notifications;

namespace SaarWorld.Services.Foundations.Notifications
{
    public partial interface INotificationService
    {
        ValueTask<List<Notification>> GetNotif();
    }
}