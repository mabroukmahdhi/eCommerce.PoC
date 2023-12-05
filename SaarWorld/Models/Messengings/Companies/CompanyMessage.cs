// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using CommunityToolkit.Mvvm.Messaging.Messages;

namespace SaarWorld.Models.Messengings.Companies
{
    public class CompanyMessage : ValueChangedMessage<CompanyToProductInfo>
    {
        public CompanyMessage(CompanyToProductInfo data) : base(data)
        {
        }
    }
}
