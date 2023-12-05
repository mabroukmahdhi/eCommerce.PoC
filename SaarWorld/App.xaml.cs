// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Brokers.Handlers.EditorHandlers;
using SaarWorld.Brokers.Licenses;
using SaarWorld.Models.Preferences;
using SaarWorld.Services.Foundations.Preferences;
using SaarWorld.Services.Views.Pages.Accounts;
using SaarWorld.Views.Pages.Accounts;
using SaarWorld.Views.Pages.AppShells;

namespace SaarWorld
{
    public partial class App : Application
    {
        private readonly IPreferenceService preferenceService;
        private readonly LoginViewService loginViewService;

        public App(
            ILicenseBroker licenseBroker,
            IEditorHandlerBroker editorHandlerBroker,
            LoginViewService loginViewService,
            IPreferenceService preferenceService)
        {
            licenseBroker.RegisterLicenses();

            InitializeComponent();

            editorHandlerBroker.AppendEditorsToMapping();

            this.loginViewService = loginViewService;
            this.preferenceService = preferenceService;

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            base.OnStart();

            var accessTokenPreference =
                preferenceService.RetrievePreferenceByKey(Preference.PreferenceTokenKey);

            if (accessTokenPreference?.Value == null)
            {
                MainPage.Navigation.PushModalAsync(new LoginPage(loginViewService));
            }
        }
    }
}