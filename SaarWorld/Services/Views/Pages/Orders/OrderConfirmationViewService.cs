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
    public partial class OrderConfirmationViewService : BaseViewService
    {
        private readonly IOrderService orderService;

        public OrderConfirmationViewService(ILocalizationService localizationService,
            IOrderService orderService)
            : base(localizationService)
        {
            this.orderService = orderService;


        }
        #region button
        [ObservableProperty]
        protected string buttonDeliveryRecieved;
        #endregion
        #region label
        [ObservableProperty]
        protected string confirmedPackageLabelText;
        [ObservableProperty]
        protected string orderQRConfirmationLabelText;
        [ObservableProperty]
        protected string totalLabelText;

        #endregion
        [RelayCommand]
        private async void DeliveryRecievedAsync()
        {
            await Shell.Current.GoToAsync(nameof(OrderConfirmedPage));

        }
        protected override void LocalizeTexts()
        {
            ButtonDeliveryRecieved = GetLocalizedString("DELIVERY_RECIEVED");
            ConfirmedPackageLabelText = GetLocalizedString("CONFIRM_THAT_THE_PACKAGE_HAS_ARRIVED");
            TotalLabelText = GetLocalizedString("TOTAL");

        }
    }
}

