// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SaarWorld.Models.Preferences;
using SaarWorld.Models.RegisterRequests;
using SaarWorld.Services.Foundations.Accounts;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Foundations.Preferences;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Accounts;

namespace SaarWorld.Services.Views.Pages.Accounts
{
    public partial class RegisterViewService : BaseViewService
    {
        private readonly IAccountService accountService;
        private readonly IPreferenceService preferenceService;

        public RegisterViewService(
            IAccountService accountService,
            IPreferenceService preferenceService,
            ILocalizationService localizationService)
            : base(localizationService)
        {
            this.accountService = accountService;
            this.preferenceService = preferenceService;
        }

        #region labels
        [ObservableProperty]
        protected string nameLabelText;
        [ObservableProperty]
        protected string userNameLabelText;
        [ObservableProperty]
        protected string passwordLabelText;
        [ObservableProperty]
        protected string emailLabelText;
        [ObservableProperty]
        protected string phoneNumberLabelText;
        [ObservableProperty]
        protected string registeraccountLabelText;
        [ObservableProperty]
        protected string repeatpasswordLabelText;
        #endregion

        #region placeholders
        [ObservableProperty]
        protected string namePlaceholder;
        [ObservableProperty]
        protected string userNamePlaceholder;
        [ObservableProperty]
        protected string passwordPlaceholder;
        [ObservableProperty]
        protected string emailPlaceholder;
        [ObservableProperty]
        protected string phoneNumberPlaceholder;
        [ObservableProperty]
        protected string repeatpasswordPlaceholder;
        #endregion

        #region buttons
        [ObservableProperty]
        protected string loginButtonText;
        [ObservableProperty]
        protected string registerButtonText;
        #endregion

        #region data properties

        [ObservableProperty]
        protected string name;
        [ObservableProperty]
        protected string userName;

        [ObservableProperty]
        protected string email;

        [ObservableProperty]
        protected string phoneNumber;

        [ObservableProperty]
        protected string password;

        [ObservableProperty]
        protected string repeatpassword;
        #endregion

        [RelayCommand]
        private async void RegisterAsync()
        {
            try
            {
                SetBusyStatus(true);

                var response = await this.accountService.RegisterAync(new RegisterRequest
                {
                    Name = Name,
                    UserName = UserName,
                    Email = Email,
                    Password = Password,
                    PhoneNumber = PhoneNumber,


                });

                this.preferenceService.AddPreference(new Preference
                {
                    Key = Preference.PreferenceTokenKey,
                    Value = response.AccessToken
                });

                await Shell.Current.GoToAsync(nameof(AccountCreatedPage));



                //await DisplayInfo($"{response.UserName} you have successfully created your account");
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
            RegisteraccountLabelText = GetLocalizedString("REGISTER A NEW ACCOUNT");
            UserNameLabelText = GetLocalizedString("USERNAME");
            PasswordLabelText = GetLocalizedString("PASSWORD");
            UserNamePlaceholder = GetLocalizedString("USERNAME_PLACEHOLDER");
            PasswordPlaceholder = GetLocalizedString("PASSWORD_PLACEHOLDER");
            NameLabelText = GetLocalizedString("NAME");
            EmailLabelText = GetLocalizedString("EMAIL");
            NamePlaceholder = GetLocalizedString("NAME_PLACEHOLDER");
            EmailPlaceholder = GetLocalizedString("EMAIL_PLACEHOLDER");
            PhoneNumberLabelText = GetLocalizedString("PHONENUMBER");
            PhoneNumberPlaceholder = GetLocalizedString("PHONENUMBER_PLACEHOLDER");
            RepeatpasswordLabelText = GetLocalizedString("REPEATPASSWORD");
            RepeatpasswordPlaceholder = GetLocalizedString("REPEATPASSWORD_PLACEHOLDER");
            LoginButtonText = GetLocalizedString("LOGIN_BUTTON");
            RegisterButtonText = GetLocalizedString("CREATE_ACCOUNT");
        }

        [RelayCommand]
        async void GoToLoginAsync()
        {

            await Shell.Current.GoToAsync(nameof(LoginPage));

        }

    }
}

