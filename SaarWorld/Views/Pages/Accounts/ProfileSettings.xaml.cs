// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Accounts;

namespace SaarWorld.Views.Pages.Accounts;

public partial class ProfileSettings : ContentPage
{
    public ProfileSettings(ProfileSettingViewService profileSettingViewService)
    {
        InitializeComponent();
        this.BindingContext = profileSettingViewService;
    }
}