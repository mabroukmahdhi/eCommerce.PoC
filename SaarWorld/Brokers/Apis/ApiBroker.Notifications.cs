// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaarWorld.Models.Notifications;

namespace SaarWorld.Brokers.Apis
{
    public partial class ApiBroker
    {
        private const string NotificationsRelativeUrl = "api/Notifications";


        public async ValueTask<List<Notification>> GetAllNotifAsync()
        {
            await Task.Delay(1000);

            return new List<Notification>()
            {
                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "Your cargo delivery has been approved",
                    ImageURl = "car.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "you got a new offer for your delivery",
                    ImageURl = "car.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "Your cargo delivery has been approved",
                    ImageURl = "box.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "Your cargo delivery has been approved",
                    ImageURl = "car.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "you got a new offer for your delivery",
                    ImageURl = "car.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "Your cargo delivery has been approved",
                    ImageURl = "box.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "Your cargo delivery has been approved",
                    ImageURl = "car.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "you got a new offer for your delivery",
                    ImageURl = "car.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "Your cargo delivery has been approved",
                    ImageURl = "box.png"
                },
                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "Your cargo delivery has been approved",
                    ImageURl = "car.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "you got a new offer for your delivery",
                    ImageURl = "car.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "Your cargo delivery has been approved",
                    ImageURl = "box.png"
                },
                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "Your cargo delivery has been approved",
                    ImageURl = "car.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "you got a new offer for your delivery",
                    ImageURl = "car.png"
                },

                new Notification
                {
                    Id = Guid.NewGuid(),
                    Content = "Your cargo delivery has been approved",
                    ImageURl = "box.png"
                }
            };
        }
    }
}