// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace SaarWorld.Brokers.Navigations
{
    public class NavigationBroker : INavigationBroker
    {
        public async ValueTask GoToAsync(string page) =>
            await Shell.Current.GoToAsync($"{page}", true);

        public async ValueTask PopModalAsync() =>
            await Application.Current.MainPage.Navigation.PopModalAsync();
    }
}