// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Accounts;

namespace SaarWorld.Views.Pages.Accounts
{
    public partial class PasswordResetPage : ContentPage
    {
        public PasswordResetPage(PasswordResetViewService passwordResetViewService)
        {
            InitializeComponent();
            this.BindingContext = passwordResetViewService;
        }
        //private async void resetBtn_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new PasswordResetVerificationPage());
        //}
    }
}