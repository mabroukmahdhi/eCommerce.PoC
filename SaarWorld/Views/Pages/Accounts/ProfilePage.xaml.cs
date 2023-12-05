// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Accounts;

namespace SaarWorld.Views.Pages.Accounts
{
    public partial class ProfilePage : ContentPage
    {

        public ProfilePage(ProfileViewService profileViewService)
        {
            InitializeComponent();
            this.BindingContext = profileViewService;

        }
    }
}