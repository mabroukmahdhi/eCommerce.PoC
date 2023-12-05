// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Foundations.Orders;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Orders;

namespace SaarWorld.Services.Views.Pages.Orders
{
    public partial class OrderQRConfirmationViewService : BaseViewService
    {
        private readonly IOrderService orderService;

        public OrderQRConfirmationViewService(ILocalizationService localizationService,
            IOrderService orderService)
            : base(localizationService)
        {
            this.orderService = orderService;


        }
        #region button
        [ObservableProperty]
        protected string buttonTrackOrder;
        #endregion
        #region label
        [ObservableProperty]
        protected string confirmedPackageLabelText;
        [ObservableProperty]
        protected string orderQRConfirmationLabelText;
        #endregion
        [RelayCommand]
        private async void TrackOrderAsync()
        {
            await Shell.Current.GoToAsync(nameof(OrderConfirmationPage));

        }
        protected override void LocalizeTexts()
        {
            ButtonTrackOrder = GetLocalizedString("TRACK_THE_ORDER");
            ConfirmedPackageLabelText = GetLocalizedString("CONFIRM_THAT_THE_PACKAGE_HAS_ARRIVED");
            OrderQRConfirmationLabelText = GetLocalizedString("ORDER_QR_CONFIRMATION");

        }
    }
}