// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.ViewModels;
using SaarWorld.Views.Pages.Orders;

namespace SaarWorld.Views.Pages.Details
{
    public partial class OrderDetailsPage : ContentPage
    {
        public OrderDetailsPage(OrderDetailsViewService ordersViewService)
        {
            InitializeComponent();

            ordersViewService.Title = $"{DeliveryDetailsPage.StartLocation} -> {DeliveryDetailsPage.EndLocation}";
            ordersViewService.PackageLocation = DeliveryDetailsPage.StartLocation;
            ordersViewService.TargetLocation = DeliveryDetailsPage.EndLocation;
            ordersViewService.Price = DeliveryDetailsPage.Price;
            ordersViewService.Distance = DeliveryDetailsPage.Distance;

            this.BindingContext = ordersViewService;
        }

        private void CancelOrder(object sender, System.EventArgs e)
        {

        }

        private async void ConfirmOrder(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(OrderConfirmedPage)}");

        }
    }
}