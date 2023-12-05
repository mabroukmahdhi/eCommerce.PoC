// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Maps;
using SaarWorld.Brokers.GeoLocations;
using SaarWorld.Services.ViewModels;

namespace SaarWorld.Views.Pages.Details
{
    public partial class DeliveryDetailsPage : ContentPage
    {
        private readonly IGeoLocationBroker geoLocationBroker;
        public static Pin StartPin;
        public static Pin EndPin;

        public static string StartLocation = string.Empty;
        public static string EndLocation = string.Empty;
        public static string Shipment = string.Empty;
        public static string Distance = string.Empty;
        public static string Price = string.Empty;
        public DeliveryDetailsPage(
            DetailsViewService detailsViewService,
            IGeoLocationBroker geoLocationBroker)
        {
            InitializeComponent();
            this.BindingContext = detailsViewService;
            this.geoLocationBroker = geoLocationBroker;
            // detailsMap.IsShowingUser = true;
        }

        private async void StartLocationTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                detailsMap.Pins.Clear();

                var locations = await this.geoLocationBroker.GetGeoLocationsAsync(e.NewTextValue);
                var location = locations?.FirstOrDefault();

                if (location != null)
                {
                    StartPin = new Microsoft.Maui.Controls.Maps.Pin
                    {
                        Address = e.NewTextValue,
                        Label = "From here",
                        Location = new Microsoft.Maui.Devices.Sensors.Location
                        {
                            Latitude = location.Latitude,
                            Longitude = location.Longitude
                        }
                    };

                    detailsMap.Pins.Add(StartPin);
                    if (EndPin != null)
                    {
                        detailsMap.Pins.Add(EndPin);
                    }


                    DrowPloyline();

                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(StartPin.Location, Microsoft.Maui.Maps.Distance.FromKilometers(1));

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        detailsMap.MoveToRegion(mapSpan);
                    });

                }

            }
            catch (Exception ex)
            {
                var str = ex.Message;
            }
        }

        private async void TargetLocationTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                detailsMap.Pins.Clear();


                var locations = await this.geoLocationBroker.GetGeoLocationsAsync(e.NewTextValue);
                var location = locations?.ToList()?.FirstOrDefault();

                if (location != null)
                {
                    EndPin = new Microsoft.Maui.Controls.Maps.Pin
                    {
                        Address = e.NewTextValue,
                        Label = "To here",
                        Location = new Microsoft.Maui.Devices.Sensors.Location
                        {
                            Latitude = location.Latitude,
                            Longitude = location.Longitude
                        }
                    };

                    if (StartPin != null)
                    {
                        detailsMap.Pins.Add(StartPin);
                    }
                    if (EndPin != null)
                    {
                        detailsMap.Pins.Add(EndPin);
                    }

                    DrowPloyline();

                    var minLatitude = Math.Min(StartPin.Location.Latitude, EndPin.Location.Latitude);
                    var maxLatitude = Math.Max(StartPin.Location.Latitude, EndPin.Location.Latitude);
                    var minLongitude = Math.Min(StartPin.Location.Longitude, EndPin.Location.Longitude);
                    var maxLongitude = Math.Max(StartPin.Location.Longitude, EndPin.Location.Longitude);

                    var centerLatitude = (minLatitude + maxLatitude) / 2;
                    var centerLongitude = (minLongitude + maxLongitude) / 2;

                    var distance = Microsoft.Maui.Maps.Distance.BetweenPositions(StartPin.Location, EndPin.Location);

                    var mapSpan = MapSpan.FromCenterAndRadius(new Location(centerLatitude, centerLongitude), distance);

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        detailsMap.MoveToRegion(mapSpan);
                    });

                }
            }
            catch (Exception ex)
            {
                var str = ex.Message;
            }
        }

        private double drivingPrice = 0;
        private double thingsPrice = 50;

        public static Microsoft.Maui.Controls.Maps.Polyline Polyline;
        private async ValueTask DrowPloyline()
        {
            if (StartPin == null || EndPin == null)
                return;


            StartLocation = StartPin.Address;
            EndLocation = EndPin.Address;

            Polyline = new Microsoft.Maui.Controls.Maps.Polyline();
            Polyline.StrokeColor = Colors.Blue;
            Polyline.StrokeWidth = 12;


            var routes = await this.geoLocationBroker.GetRoutes(StartPin.Address, EndPin.Address);

            detailsMap.MapElements.Clear();

            if (routes != null && routes.Length > 0)
            {
                var route = routes[0];
                if (route.Legs != null)
                {
                    foreach (var leg in route.Legs)
                    {
                        if (leg.Steps != null)
                        {
                            foreach (var step in leg.Steps)
                            {
                                // The start location of the step
                                Polyline.Geopath.Add(new Location
                                {
                                    Latitude = step.StartLocation.Lat,
                                    Longitude = step.StartLocation.Lng,
                                });
                                // The end location of the step
                                Polyline.Geopath.Add(new Location
                                {
                                    Latitude = step.EndLocation.Lat,
                                    Longitude = step.EndLocation.Lng,
                                });
                            }
                        }
                    }
                }



                detailsMap.MapElements.Add(Polyline);
                int totalDistanceInMeters = 0;
                var totalDuration = string.Empty;
                if (route.Legs != null)
                {
                    foreach (var leg in route.Legs)
                    {
                        if (leg.Distance != null)
                        {
                            totalDistanceInMeters += leg.Distance.Value;
                            totalDuration = leg.Duration.Text;
                        }
                    }
                }
                var distanceKm = totalDistanceInMeters / 1000;
                drivingPrice = distanceKm * 1.5;
                DistanceLabel.Text = Distance = $"{distanceKm:0.0} KM ({totalDuration})";
                DurationLabel.Text = totalDuration;
                PriceLabel.Text = Price = $"{drivingPrice + thingsPrice:0.00} €";
            }

        }

        private void ShipmentTextChanged(object sender, TextChangedEventArgs e)
        {
            Shipment = e.NewTextValue;

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                thingsPrice = 50;
            }
            else
            {
                this.thingsPrice = new Random().Next(50, 250);
            }

            PriceLabel.Text = Price = $"{drivingPrice + thingsPrice:0.00} €";
        }
    }
}
