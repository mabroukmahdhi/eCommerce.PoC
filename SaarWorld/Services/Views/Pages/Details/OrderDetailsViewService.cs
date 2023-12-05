// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

/* Unmerged change from project 'SaarWorld (net7.0-ios)'
Before:
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
After:
// eCommerce app using .NET MAUI
// ---------------------------------------------------------------
*/
implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using SaarWorld.Models.Messengings.Deliveries;
using SaarWorld.Services.Foundations.Cargoes;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Views.Bases;

namespace SaarWorld.Services.ViewModels
{
    public partial class OrderDetailsViewService : BaseViewService
    {
        private readonly ICargoService cargoService;
        private readonly DetailsViewService detailsViewService;

        public OrderDetailsViewService(
            ILocalizationService localizationService,
            ICargoService cargoService)
            : base(localizationService)
        {
            this.cargoService = cargoService;
            MoveLocation = moveLocation;
            Shipment = shipment;
            ShipmentSize = shipmentSize;
            PackageLocation = packageLocation;
            TargetLocation = targetLocation;

            WeakReferenceMessenger.Default.Register<DeliveryMessage>(this, OnDeliveryDetailsReceived);
        }

        private void OnDeliveryDetailsReceived(object recipient, DeliveryMessage message)
        {
            MoveLocation = message.Value.MoveLocation;
            Shipment = message.Value.Shipment;
            ShipmentSize = message.Value.ShipmentSize;
            TargetLocation = message.Value.TargetLocation;
            PackageLocation = message.Value.PackageLocation;

        }

        #region label
        [ObservableProperty]
        protected string pendingTextLabel;
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
        protected string orderDetailsText;
        #endregion
        #region button
        [ObservableProperty]
        protected string buttonCallCompany;
        [ObservableProperty]
        protected string buttonCancelOrder;
        #endregion
        #region data proporty
        [ObservableProperty]
        protected string name;
        [ObservableProperty]
        protected string state;
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
        protected string distance;
        [ObservableProperty]
        protected string price;
        #endregion

        public async void GetOrder()
        {
            try
            {
                SetBusyStatus(true);
                IsBusy = true;
                var response = await this.cargoService.OrderAsync();

                Name = Name;
                State = State;
            }
            catch (Exception exception)
            {
                await DisplayError(exception.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
        protected override void LocalizeTexts()
        {
            OrderDetailsText = GetLocalizedString("ORDER_DETAILS_PAGE");
            PendingTextLabel = GetLocalizedString("PENDING_FOR_THE_APPROVAL");
            ButtonCallCompany = GetLocalizedString("CALL_COMPANY");
            MoveLabelText = GetLocalizedString("WHAT_ARE_YOU_GOING_TO_MOVE");
            ShipmentLabelText = GetLocalizedString("DESCRIBE_THE_SHIPMENT");
            ShipmentSizeLabelText = GetLocalizedString("WHAT_IS_THE_SIZE_OF_THE_SHIPMENT");
            PriceLabelText = GetLocalizedString("TOTAL_PRICE");
            DistanceLabelText = GetLocalizedString("DISTANCE");
            ButtonCancelOrder = GetLocalizedString("CANCEL_ORDER");
        }
    }

}
