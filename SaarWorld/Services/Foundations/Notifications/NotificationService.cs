// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Brokers.Apis;
using SaarWorld.Models.Notifications;

namespace SaarWorld.Services.Foundations.Notifications
{
    public partial class NotificationService : INotificationService
    {
        private readonly IApiBroker apiBroker;

        public NotificationService(IApiBroker apiBroker)
        {
            this.apiBroker = apiBroker;
        }
        public async ValueTask<List<Notification>> GetNotif() =>
            await this.apiBroker.GetAllNotifAsync();
    }
}