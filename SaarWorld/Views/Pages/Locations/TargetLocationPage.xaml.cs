// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;

namespace SaarWorld.Views.Pages.Locations;

public partial class TargetLocationPage : ContentPage
{
    public TargetLocationPage()
    {
        InitializeComponent();
    }

    private async void targetLocMap_MapClicked(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e)
    {
        var loc = e.Location;
        // TODO: Set location in entry field
        targetLocMap.Pins.Add(new Pin
        {
            Label = "Current Location",
            Location = loc
        });

        //await Navigation.PushAsync(new DeliveryDetailsPage());
    }
}