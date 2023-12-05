// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Views.Pages.Accounts;
using SaarWorld.Views.Pages.Cargoes;
using SaarWorld.Views.Pages.ComingSoons;
using SaarWorld.Views.Pages.Companies;
using SaarWorld.Views.Pages.Details;
using SaarWorld.Views.Pages.Errors;
using SaarWorld.Views.Pages.Homes;
using SaarWorld.Views.Pages.Locations;
using SaarWorld.Views.Pages.Notifications;
using SaarWorld.Views.Pages.Orders;
using SaarWorld.Views.Pages.Products;

namespace SaarWorld.Views.Pages.AppShells
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(AccountCreatedPage), typeof(AccountCreatedPage));
            Routing.RegisterRoute(nameof(CargoPage), typeof(CargoPage));
            Routing.RegisterRoute(nameof(CompanyPage), typeof(CompanyPage));
            Routing.RegisterRoute(nameof(ComingSoonPage), typeof(ComingSoonPage));
            Routing.RegisterRoute(nameof(CurrentLocationPage), typeof(CurrentLocationPage));
            Routing.RegisterRoute(nameof(DeliveryDetailsPage), typeof(DeliveryDetailsPage));
            Routing.RegisterRoute(nameof(ErrorPage), typeof(ErrorPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
            Routing.RegisterRoute(nameof(OrderConfirmationPage), typeof(OrderConfirmationPage));
            Routing.RegisterRoute(nameof(OrderConfirmedPage), typeof(OrderConfirmedPage));
            Routing.RegisterRoute(nameof(OrderDetailsPage), typeof(OrderDetailsPage));
            Routing.RegisterRoute(nameof(OrdersPage), typeof(OrdersPage));
            Routing.RegisterRoute(nameof(OrderQRConfirmation), typeof(OrderQRConfirmation));
            Routing.RegisterRoute(nameof(PasswordResetPage), typeof(PasswordResetPage));
            Routing.RegisterRoute(nameof(PasswordResetVerificationPage), typeof(PasswordResetVerificationPage));
            Routing.RegisterRoute(nameof(PasswordResetVerifiedPage), typeof(PasswordResetVerifiedPage));
            Routing.RegisterRoute(nameof(ProductsPage), typeof(ProductsPage));
            Routing.RegisterRoute(nameof(ProfileSettings), typeof(ProfileSettings));
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(TargetLocationPage), typeof(TargetLocationPage));
        }
    }
}