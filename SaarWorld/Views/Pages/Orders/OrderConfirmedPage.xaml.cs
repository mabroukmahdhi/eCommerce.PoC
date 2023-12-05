// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Orders;

namespace SaarWorld.Views.Pages.Orders;

public partial class OrderConfirmedPage : ContentPage
{
    public OrderConfirmedPage(OrderConfirmedViewService orderConfirmedViewService)
    {
        InitializeComponent();
        this.BindingContext = orderConfirmedViewService;
    }
}