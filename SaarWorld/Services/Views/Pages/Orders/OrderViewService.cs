// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SaarWorld.Models.Orders;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Foundations.Orders;
using SaarWorld.Services.Views.Bases;

namespace SaarWorld.Services.Views.Pages.Orders
{
    public partial class OrderViewService : BaseViewService
    {
        private readonly IOrderService orderService;

        public OrderViewService(ILocalizationService localizationService,
            IOrderService orderService)
            : base(localizationService)
        {
            this.orderService = orderService;
            GetOrders();


        }
        #region label
        [ObservableProperty]
        protected string ordersPage;
        [ObservableProperty]
        protected string nameLabelText;
        [ObservableProperty]
        protected string priceLabelText;
        [ObservableProperty]
        protected Boolean completed;
        #endregion
        #region data properties
        [ObservableProperty]
        protected ObservableCollection<Order> orderList = new ObservableCollection<Order>();
        #endregion


        public async void GetOrders()
        {
            try
            {
                IsBusy = true;

                List<Order> orders = await orderService.GetOrdersAsync();
                OrderList = new ObservableCollection<Order>(orders);
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
            NameLabelText = GetLocalizedString("Name");
            OrdersPage = GetLocalizedString("ORDERS");
            PriceLabelText = GetLocalizedString("TOTAL_PRICE");

        }
    }


}

