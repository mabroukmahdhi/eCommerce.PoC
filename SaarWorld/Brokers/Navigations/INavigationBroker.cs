// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;

namespace SaarWorld.Brokers.Navigations
{
    public interface INavigationBroker
    {
        ValueTask GoToAsync(string page);
        ValueTask PopModalAsync();
    }
}