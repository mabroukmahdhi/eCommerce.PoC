// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;
using SaarWorld.Brokers.GeoLocations;
using SaarWorld.Services.Views.Pages.Locations;

namespace SaarWorld.Views.Pages.Locations
{
    public partial class CurrentLocationPage : ContentPage
    {
        public CurrentLocationPage(CurrentLocationViewService currentLocationViewService)
        {
            InitializeComponent();
            this.BindingContext = currentLocationViewService;
            InitializeMap();
        }
        private Pin _pin = new Pin();

        private async void InitializeMap()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
                if (location != null)
                {
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(location.Latitude, location.Longitude), Microsoft.Maui.Maps.Distance.FromMiles(1)));
                }
            }
            catch (FeatureNotEnabledException fnee)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pex)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        private void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            map.Pins.Clear();
            _pin.Location = e.Location;
            _pin.Label = "Selected Location";
            map.Pins.Add(_pin);
        }

        private async void OnConfirmClicked(object sender, EventArgs e)
        {
            if (_pin.Location != null)
            {

                try
                {
                    var addresses = await new GeoLocationBroker().ReverseGeocodeAsync(
                        latitude: _pin.Location.Latitude,
                        longitude: _pin.Location.Longitude);

                    await DisplayAlert("Location Selected", addresses, "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.ToString(), "OK");
                }

            }
        }
    }
}