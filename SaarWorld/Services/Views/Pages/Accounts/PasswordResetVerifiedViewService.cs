// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SaarWorld.Models.PasswordResetVerifiedRequests;
using SaarWorld.Models.Preferences;
using SaarWorld.Services.Foundations.Accounts;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Foundations.Preferences;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Accounts;

namespace SaarWorld.Services.Views.Pages.Accounts
{
    public partial class PasswordResetVerifiedViewService : BaseViewService
    {
        private readonly IAccountService accountService;
        private readonly IPreferenceService preferenceService;

        public PasswordResetVerifiedViewService(
         ILocalizationService localizationService,
            IAccountService accountService,
            IPreferenceService preferenceService)
            : base(localizationService)
        {
            this.accountService = accountService;
            this.preferenceService = preferenceService;
        }

        #region labels
        [ObservableProperty]
        protected string titleLabelText;
        [ObservableProperty]
        protected string passwordLabelText;
        [ObservableProperty]
        protected string newPasswordLabelText;
        [ObservableProperty]
        protected string passwordRepeatLabelText;
        #endregion
        #region buttons
        [ObservableProperty]
        protected string resetButton;
        #endregion
        #region placeholder
        [ObservableProperty]
        protected string passwordPlaceholder;
        [ObservableProperty]
        protected string passwordRepeatPlaceholder;
        #endregion
        #region data properties
        [ObservableProperty]
        protected string password;
        [ObservableProperty]
        protected string resetPassword;
        #endregion


        [RelayCommand]
        private async void PasswordResetVerifiedAsync()
        {
            try
            {
                SetBusyStatus(true);

                var response = await this.accountService.PasswordResetVerifiedAync(new PasswordResetVerifiedRequest
                {
                    ResetPassword = ResetPassword,
                    Password = Password
                });

                this.preferenceService.AddPreference(new Preference
                {
                    Key = Preference.PreferenceTokenKey,
                    Value = response.AccessToken
                });

                await Shell.Current.GoToAsync(nameof(LoginPage));
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

        protected override void LocalizeTexts()
        {
            TitleLabelText = GetLocalizedString("PASSWORD_RESET");
            NewPasswordLabelText = GetLocalizedString("ENTER A NEW SAFE PASSWORD PLEASE!");
            PasswordLabelText = GetLocalizedString("PASSWORD");
            PasswordPlaceholder = GetLocalizedString("PASSWORD_PLACEHOLDER");
            PasswordRepeatLabelText = GetLocalizedString("REPEATPASSWORD");
            PasswordRepeatPlaceholder = GetLocalizedString("REPEATPASSWORD_PLACEHOLDER");
            ResetButton = GetLocalizedString("RESET");

        }

    }
}
