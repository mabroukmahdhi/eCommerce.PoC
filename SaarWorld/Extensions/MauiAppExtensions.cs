// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using SaarWorld.Brokers.Apis;
using SaarWorld.Brokers.Configurations;
using SaarWorld.Brokers.DateTimes;
using SaarWorld.Brokers.GeoLocations;
using SaarWorld.Brokers.Handlers.EditorHandlers;
using SaarWorld.Brokers.Licenses;
using SaarWorld.Brokers.Localizations;
using SaarWorld.Brokers.Navigations;
using SaarWorld.Brokers.Preferences;
using SaarWorld.Brokers.Serializations;
using SaarWorld.Services.Foundations.Accounts;
using SaarWorld.Services.Foundations.Cargoes;
using SaarWorld.Services.Foundations.Companies;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Foundations.Notifications;
using SaarWorld.Services.Foundations.Orders;
using SaarWorld.Services.Foundations.Preferences;
using SaarWorld.Services.ViewModels;
using SaarWorld.Services.Views.Pages.Accounts;
using SaarWorld.Services.Views.Pages.Cargoes;
using SaarWorld.Services.Views.Pages.Companies;
using SaarWorld.Services.Views.Pages.Homes;
using SaarWorld.Services.Views.Pages.Locations;
using SaarWorld.Services.Views.Pages.Orders;
using SaarWorld.Services.Views.Pages.Products;
using SaarWorld.Views.Pages.Accounts;
using SaarWorld.Views.Pages.Cargoes;
using SaarWorld.Views.Pages.Companies;
using SaarWorld.Views.Pages.Details;
using SaarWorld.Views.Pages.Homes;
using SaarWorld.Views.Pages.Locations;
using SaarWorld.Views.Pages.Notifications;
using SaarWorld.Views.Pages.Orders;
using SaarWorld.Views.Pages.Products;

namespace SaarWorld.Extensions
{
    public static class MauiAppExtensions
    {
        public static MauiAppBuilder ConfigureSaarApp(this MauiAppBuilder builder)
        {
            builder.UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Cairo.ttf", "Cairo");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
            .AddHttpClient()
            .AddBrokers()
            .AddPagesAndViewServices()
            .AddFoundationServices()
            .AddHandlers()
            .UseMauiMaps();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder;
        }

        private static MauiAppBuilder AddHttpClient(this MauiAppBuilder builder)
        {
            var configurationBroker = new ConfigurationBroker();
            Uri apiUri = new(configurationBroker.ApiBaseUrl);

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = apiUri });

            return builder;
        }

        private static MauiAppBuilder AddBrokers(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IConfigurationBroker, ConfigurationBroker>();
            builder.Services.AddSingleton<ILicenseBroker, LicenseBroker>();
            builder.Services.AddSingleton<IPreferenceBroker, PreferenceBroker>();
            builder.Services.AddSingleton<IApiBroker, ApiBroker>();
            builder.Services.AddSingleton<ISerializationBroker, SerializationBroker>();
            builder.Services.AddSingleton<INavigationBroker, NavigationBroker>();
            builder.Services.AddSingleton<IDateTimeBroker, DateTimeBroker>();
            builder.Services.AddSingleton<IGeoLocationBroker, GeoLocationBroker>();
            builder.Services.AddSingleton<ILocalizationBroker, LocalizationBroker>();

            return builder;
        }

        private static MauiAppBuilder AddFoundationServices(this MauiAppBuilder builder)
        {
            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<ILocalizationService, LocalizationService>();
            builder.Services.AddSingleton<IPreferenceService, PreferenceService>();
            builder.Services.AddSingleton<IAccountService, AccountService>();
            builder.Services.AddSingleton<ICompanyService, CompanyService>();
            builder.Services.AddSingleton<IOrderService, OrderService>();
            builder.Services.AddSingleton<INotificationService, NotificationService>();
            builder.Services.AddSingleton<ILocationService, LocationService>();
            builder.Services.AddSingleton<ICargoService, CargoService>();

            return builder;
        }

        private static MauiAppBuilder AddPagesAndViewServices(this MauiAppBuilder builder)
        {
            #region Pages
            builder.Services.AddTransient<AccountCreatedPage>();
            builder.Services.AddTransient<CargoPage>();
            builder.Services.AddTransient<CompanyPage>();
            builder.Services.AddTransient<CurrentLocationPage>();
            builder.Services.AddTransient<DeliveryDetailsPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<NotificationsPage>();
            builder.Services.AddTransient<OrderConfirmationPage>();
            builder.Services.AddTransient<OrderConfirmedPage>();
            builder.Services.AddTransient<OrderDetailsPage>();
            builder.Services.AddTransient<OrderQRConfirmation>();
            builder.Services.AddTransient<OrdersPage>();
            builder.Services.AddTransient<PasswordResetPage>();
            builder.Services.AddTransient<PasswordResetVerifiedPage>();
            builder.Services.AddTransient<PasswordResetVerificationPage>();
            builder.Services.AddTransient<ProductsPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<ProfileSettings>();
            builder.Services.AddTransient<RegistrationPage>();
            #endregion

            #region ViewModels
            builder.Services.AddTransient<AccountCreatedViewService>();
            builder.Services.AddTransient<CargoViewService>();
            builder.Services.AddTransient<CompanyViewService>();
            builder.Services.AddTransient<CurrentLocationViewService>();
            builder.Services.AddTransient<DetailsViewService>();
            builder.Services.AddTransient<HomeViewService>();
            builder.Services.AddTransient<LoginViewService>();
            builder.Services.AddTransient<NotificationsViewService>();
            builder.Services.AddTransient<OrderConfirmationViewService>();
            builder.Services.AddTransient<OrderConfirmedViewService>();
            builder.Services.AddTransient<OrderDetailsViewService>();
            builder.Services.AddTransient<OrderQRConfirmationViewService>();
            builder.Services.AddTransient<OrderViewService>();
            builder.Services.AddTransient<PasswordResetViewService>();
            builder.Services.AddTransient<PasswordResetVerifiedViewService>();
            builder.Services.AddTransient<PasswordResetVerificationViewService>();
            builder.Services.AddTransient<ProductViewService>();
            builder.Services.AddTransient<ProfileSettingViewService>();
            builder.Services.AddTransient<ProfileViewService>();
            builder.Services.AddTransient<RegisterViewService>();
            #endregion

            return builder;
        }

        private static MauiAppBuilder AddHandlers(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IEditorHandlerBroker, EditorHandlerBroker>();

            return builder;
        }
    }
}