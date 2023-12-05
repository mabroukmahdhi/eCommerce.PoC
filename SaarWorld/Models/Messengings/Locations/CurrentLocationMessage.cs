// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using CommunityToolkit.Mvvm.Messaging.Messages;

namespace SaarWorld.Models.Messengings.Locations
{
    public class CurrentLocationMessage : ValueChangedMessage<CurrentLocationToDeliveryInfo>
    {
        public CurrentLocationMessage(CurrentLocationToDeliveryInfo data) : base(data)
        {
        }
    }
}