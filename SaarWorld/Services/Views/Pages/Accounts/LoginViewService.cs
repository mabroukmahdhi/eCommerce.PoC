// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

/* Unmerged change from project 'SaarWorld (net7.0-ios)'
Before:
// See License.txt in the project root for license information.
After:
// eCommerce app using information.
*/
implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SaarWorld.Brokers.Navigations;
using SaarWorld.Models.LoginRequests;
using SaarWorld.Models.Preferences;
using SaarWorld.Services.Foundations.Accounts;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Foundations.Preferences;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Accounts;

namespace SaarWorld.Services.Views.Pages.Accounts
{
    public partial class LoginViewService : BaseViewService
    {
        private readonly IAccountService accountService;
        private readonly IPreferenceService preferenceService;
        private readonly INavigationBroker navigationBroker;

        public LoginViewService(
            ILocalizationService localizationService,
            IAccountService accountService,
            IPreferenceService preferenceService,
            INavigationBroker navigationBroker)
            : base(localizationService)
        {
            this.accountService = accountService;
            this.preferenceService = preferenceService;
            this.navigationBroker = navigationBroker;

            this.UserName = "mabrouk@mahdhi.com";
            this.Password = "M@hdhi!$1";
        }

        #region text properties

        #region labels
        [ObservableProperty]
        protected string userNameLabelText;
        [ObservableProperty]
        protected string passwordLabelText;
        [ObservableProperty]
        protected string forgetPasswordLabelText;
        #endregion

        #region placeholders

        [ObservableProperty]
        protected string userNamePlaceholder;
        [ObservableProperty]
        protected string passwordPlaceholder;
        #endregion

        #region buttons
        [ObservableProperty]
        protected string loginButtonText;
        [ObservableProperty]
        protected string registerButtonText;
        #endregion

        #endregion

        #region data properties

        [ObservableProperty]
        protected string userName;
        [ObservableProperty]
        protected string password;
        #endregion

        [RelayCommand]
        private async void LoginAsync()
        {
            try
            {
                SetBusyStatus(true);

                var response = await this.accountService.LoginAync(new LoginRequest
                {
                    UserName = UserName,
                    Password = Password,
                });

                this.preferenceService.AddPreference(new Preference
                {
                    Key = Preference.PreferenceTokenKey,
                    Value = response.AccessToken
                });

                //await DisplayInfo($"user logged in with token:{response.AccessToken}");

                await this.navigationBroker.PopModalAsync();
            }
            catch (Exception exception)
            {
                await DisplayError(exception.Message);
            }
            finally
            {
                SetBusyStatus(false);
            }
        }

        [RelayCommand]
        private async void ResetPassword()
        {
            await Shell.Current.GoToAsync(nameof(PasswordResetPage));
        }

        protected override void LocalizeTexts()
        {
            UserNameLabelText = GetLocalizedString("USERNAME");
            ForgetPasswordLabelText = GetLocalizedString("FORGET_PASSWORD");
            PasswordLabelText = GetLocalizedString("PASSWORD");
            UserNamePlaceholder = GetLocalizedString("USERNAME_PLACEHOLDER");
            PasswordPlaceholder = GetLocalizedString("PASSWORD_PLACEHOLDER");
            LoginButtonText = GetLocalizedString("LOGIN_BUTTON");
            RegisterButtonText = GetLocalizedString("CREATE_ACCOUNT");
        }
    }
}
