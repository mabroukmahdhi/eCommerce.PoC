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
using SaarWorld.Views.Pages.Homes;

namespace SaarWorld.Services.Views.Pages.Orders
{
    public partial class OrderConfirmedViewService : BaseViewService
    {
        private readonly IOrderService orderService;
        public OrderConfirmedViewService(ILocalizationService localizationService,
            IOrderService orderService)
            : base(localizationService)
        {
            this.orderService = orderService;
        }
        #region button
        [ObservableProperty]
        protected string buttonBackToHome;
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
        private async void BackToHomeAsync()
        {
            await Shell.Current.GoToAsync($"///{nameof(HomePage)}");

        }
        protected override void LocalizeTexts()
        {
            ButtonBackToHome = GetLocalizedString("BACK_TO_HOME");
            ConfirmedPackageLabelText = GetLocalizedString("THE_ORDER_HAS_BEEN_CONFIRMED");
            OrderQRConfirmationLabelText = GetLocalizedString("ORDER_QR_CONFIRMATION");
        }
    }
}

