// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Homes;

namespace SaarWorld.Views.Pages.Homes
{
    public partial class HomePage : ContentPage
    {
        public HomePage(HomeViewService homeViewService)
        {
            InitializeComponent();

            this.BindingContext = homeViewService;
        }
    }
}