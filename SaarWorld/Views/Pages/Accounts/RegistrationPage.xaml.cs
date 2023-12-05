// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Accounts;

namespace SaarWorld.Views.Pages.Accounts
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage(RegisterViewService registerViewService)
        {
            InitializeComponent();

            this.BindingContext = registerViewService;
        }
        //private async void loginBtn_Clicked(object sender, EventArgs e)
        //{
        //    //await Navigation.PushAsync(new LoginPage());
        //}

        //private async void registerBtn_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new AccountCreatedPage());
        //}
    }
}