// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Accounts;

namespace SaarWorld.Views.Pages.Accounts;

public partial class AccountCreatedPage : ContentPage
{
    public AccountCreatedPage(AccountCreatedViewService accountCreatedViewService)
    {
        InitializeComponent();
        this.BindingContext = accountCreatedViewService;
    }
    //private async void startBtn_Clicked(object sender, EventArgs e)
    //{
    //    await Navigation.PushAsync(new HomePage());
    //}
}