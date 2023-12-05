// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;

namespace SaarWorld.Models.Notifications
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string ImageURl { get; set; }
    }
}
