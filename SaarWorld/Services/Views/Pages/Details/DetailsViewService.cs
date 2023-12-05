// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

/* Unmerged change from project 'SaarWorld (net7.0-ios)'
Before:
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
After:
// See app using .NET MAUI
// ---------------------------------------------------------------
*/
implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls;
using SaarWorld.Brokers.GeoLocations;
using SaarWorld.Models.GeoLocations;
using SaarWorld.Models.Messengings.Deliveries;
using SaarWorld.Services.Foundations.Companies;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Details;
using SaarWorld.Views.Pages.Locations;

namespace SaarWorld.Services.ViewModels
{
    public partial class DetailsViewService : BaseViewService
    {

        private readonly ICompanyService cargoService;
        private readonly IGeoLocationBroker geoLocationBroker;

        public DetailsViewService(
            ILocalizationService localizationService,
           ICompanyService cargoService,
           IGeoLocationBroker geoLocationBroker)
            : base(localizationService)
        {
            this.cargoService = cargoService;
            this.geoLocationBroker = geoLocationBroker;
            PackageLocation = packageLocation;
        }

        #region label
        [ObservableProperty]
        protected string moveLabelText;
        [ObservableProperty]
        protected string shipmentLabelText;
        [ObservableProperty]
        protected string shipmentSizeLabelText;
        [ObservableProperty]
        protected string priceLabelText;
        [ObservableProperty]
        protected string distanceLabelText;
        [ObservableProperty]
        protected string directionsLabelText;
        [ObservableProperty]
        protected string deliveryDetailsLabelText;
        #endregion

        #region placeholder
        [ObservableProperty]
        protected string packageLocationPlaceholder;
        [ObservableProperty]
        protected string deliveryLocationPlaceholder;
        [ObservableProperty]
        protected string movePlaceholder;
        [ObservableProperty]
        protected string shipmentPlaceholder;
        [ObservableProperty]
        protected string shipmentsizePlaceholder;
        #endregion

        #region button
        [ObservableProperty]
        protected string buttonPlaceOrderText;
        #endregion

        #region data proporty
        [ObservableProperty]
        protected string packageLocation;
        [ObservableProperty]
        protected string targetLocation;
        [ObservableProperty]
        protected string moveLocation;
        [ObservableProperty]
        protected string shipment;
        [ObservableProperty]
        protected string shipmentSize;
        [ObservableProperty]
        GeoLocation distance;
        [ObservableProperty]
        protected double price;
        #endregion


        private async void GoToCurrentLocation()

        {
            await Shell.Current.GoToAsync(nameof(CurrentLocationPage));
            //PackageLocation = message.Value.PackageLocation;

        }


        private async void GoToTargetLocation()
        {
        }

        [RelayCommand]
        public async Task StartLocationChanged(string newLocation)
        {
            await Shell.Current.DisplayAlert("From", newLocation, "Ok");
        }

        [RelayCommand]
        public async Task EndLocationChanged(string newLocation)
        {
            await Shell.Current.DisplayAlert("To", newLocation, "Ok");
        }

        [RelayCommand]
        private async void PlaceOrderAsync()
        {
            try
            {
                SetBusyStatus(true);

                //var response = await this.cargoService.DeliveryAsync(new Delivery
                //{
                //    PackageLocation = this.PackageLocation,
                //    TargetLocation = this.TargetLocation,
                //    MoveLocation = MoveLocation,
                //    Shipment = Shipment,
                //    ShipmentSize = ShipmentSize,
                //    Price = Price,
                //    Distance = Distance,
                //});

                //await Shell.Current.GoToAsync($"{nameof(OrderDetailsPage)}?moveLocation={response.MoveLocation}");

                await Shell.Current.GoToAsync(nameof(OrderDetailsPage));

                WeakReferenceMessenger.Default.Send(new DeliveryMessage(new DeliveryToOrderInfo()
                {
                    MoveLocation = MoveLocation,
                    Shipment = Shipment,
                    ShipmentSize = ShipmentSize,
                    PackageLocation = PackageLocation,
                    TargetLocation = TargetLocation
                }));
            }

            catch (Exception exception)
            {
                await DisplayError(exception.Message);
            }
            finally
            {
                SetBusyStatus(false);
            }
        }

        protected override void LocalizeTexts()
        {
            DeliveryDetailsLabelText = "Relocation details";//GetLocalizedString("DELIVERY_DETAILS");
            DirectionsLabelText = GetLocalizedString("DIRECTIONS");
            ButtonPlaceOrderText = GetLocalizedString("PLACE_ORDER_NOW");
            MoveLabelText = GetLocalizedString("WHAT_ARE_YOU_GOING_TO_MOVE");
            ShipmentLabelText = GetLocalizedString("DESCRIBE_THE_SHIPMENT");
            ShipmentSizeLabelText = GetLocalizedString("WHAT_IS_THE_SIZE_OF_THE_SHIPMENT");
            PriceLabelText = GetLocalizedString("TOTAL_PRICE");
            DistanceLabelText = GetLocalizedString("DISTANCE");
            PackageLocationPlaceholder = "From address";//GetLocalizedString("PACKAGE_LOCATION");
            DeliveryLocationPlaceholder = "To address";//GetLocalizedString("DELIVERY_LOCATION");
            MovePlaceholder = GetLocalizedString("I_AM_MOVING_MY_HOME...");
            ShipmentPlaceholder = GetLocalizedString("TWO_CHARIRS_,_ONE_DOOR_;_2_;_BOXES...");
            ShipmentsizePlaceholder = GetLocalizedString("IT'S_A_3_METERS_*_METERS_AND_WEIGHT_5KG...");


        }
    }
}