// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SaarWorld.Models.Preferences;
using SaarWorld.Services.Foundations.Accounts;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Foundations.Preferences;
using SaarWorld.Services.Views.Bases;


using SaarWorld.Views.Pages.Accounts;

namespace SaarWorld.Services.Views.Pages.Accounts
{
    public partial class ProfileViewService : BaseViewService
    {
        private readonly IAccountService accountService;
        private readonly IPreferenceService preferenceService;
        private readonly LoginPage loginPage;


        public ProfileViewService(ILocalizationService localizationService,
            IAccountService accountService,
            IPreferenceService preferenceService,
            LoginPage loginPage)
            : base(localizationService)
        {
            this.accountService = accountService;
            this.preferenceService = preferenceService;
            this.loginPage = loginPage;
        }
        #region labels
        [ObservableProperty]
        protected string nameLabelText;
        [ObservableProperty]
        protected string userNameLabelText;
        [ObservableProperty]
        protected string emailLabelText;
        [ObservableProperty]
        protected string phoneNumberLabelText;
        [ObservableProperty]
        protected string addressLabelText;
        #endregion
        #region button
        [ObservableProperty]
        protected string editAccountButtonText;
        [ObservableProperty]
        protected string deletAccountButtonText;
        [ObservableProperty]
        protected string forgotButtonText;
        #endregion

        [RelayCommand]
        private async Task GoToEditProfileAsync()
        {

            await Shell.Current.GoToAsync(nameof(ProfileSettings));
        }

        [RelayCommand]
        private void LogoutAsnyc()
        {
            this.preferenceService.RemovePreferenceByKey(Preference.PreferenceTokenKey);
            Application.Current.MainPage = this.loginPage;
        }

        protected override void LocalizeTexts()
        {
            NameLabelText = GetLocalizedString("NAME");
            UserNameLabelText = GetLocalizedString("USERNAME");
            EmailLabelText = GetLocalizedString("EMAIL");
            PhoneNumberLabelText = GetLocalizedString("PHONENUMBER");
            AddressLabelText = GetLocalizedString("ADDRESS");
            EditAccountButtonText = GetLocalizedString("EDIT_ACCOUNT");
            DeletAccountButtonText = GetLocalizedString("DELETE_ACCOUNT");
            ForgotButtonText = GetLocalizedString("FORGET_PASSWORD");
        }
    }
}