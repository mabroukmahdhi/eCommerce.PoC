// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.ViewModels;

namespace SaarWorld.Views.Pages.Notifications;

public partial class NotificationsPage : ContentPage
{
    public NotificationsPage(NotificationsViewService notificationsViewService)
    {
        InitializeComponent();
        this.BindingContext = notificationsViewService;
    }
}