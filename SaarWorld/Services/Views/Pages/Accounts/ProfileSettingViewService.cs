// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaarWorld.Models.Profiles;
using SaarWorld.Services.Foundations.Accounts;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Foundations.Preferences;
using SaarWorld.Services.Views.Bases;


namespace SaarWorld.Services.Views.Pages.Accounts
{
    public partial class ProfileSettingViewService : BaseViewService
    {

        private readonly IAccountService accountService;
        private readonly IPreferenceService preferenceService;


        public ProfileSettingViewService(ILocalizationService localizationService,
            IAccountService accountService,
            IPreferenceService preferenceService)
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
        protected string emailLabelText;
        [ObservableProperty]
        protected string phoneNumberLabelText;
        [ObservableProperty]
        protected string addressLabelText;
        #endregion

        #region placeholder
        [ObservableProperty]
        protected string namePlaceholder;
        [ObservableProperty]
        protected string userNamePlaceholder;
        [ObservableProperty]
        protected string emailPlaceholder;
        [ObservableProperty]
        protected string phoneNumberPlaceholder;
        [ObservableProperty]
        protected string addressPlaceholder;
        #endregion

        #region button
        [ObservableProperty]
        protected string saveButtonText;
        [ObservableProperty]
        protected string cancelButtonText;
        #endregion

        #region data properties

        [ObservableProperty]
        protected string userName;
        [ObservableProperty]
        protected string name;
        [ObservableProperty]
        protected string email;
        [ObservableProperty]
        protected string address;
        [ObservableProperty]
        protected string phone;

        #endregion


        [RelayCommand]
        private async void EditProfileAsync()
        {
            try
            {
                SetBusyStatus(true);

                var response = await this.accountService.PutProfileSettingAync(new Profile
                {
                    Name = Name,
                    UserName = UserName,
                    Address = Address,
                    Phone = Phone,
                    Email = Email

                });

                await DisplayInfo($"you have been updated your account successfully");
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
            NameLabelText = GetLocalizedString("NAME");
            UserNameLabelText = GetLocalizedString("USERNAME");
            EmailLabelText = GetLocalizedString("EMAIL");
            PhoneNumberLabelText = GetLocalizedString("PHONENUMBER");
            AddressLabelText = GetLocalizedString("ADDRESS");
            NamePlaceholder = GetLocalizedString("NAME");
            UserNamePlaceholder = GetLocalizedString("USERNAME");
            EmailPlaceholder = GetLocalizedString("EMAIL");
            PhoneNumberPlaceholder = GetLocalizedString("PHONENUMBER");
            AddressPlaceholder = GetLocalizedString("ADDRESS");
            SaveButtonText = GetLocalizedString("SAVE");
            CancelButtonText = GetLocalizedString("CANCEL");

        }
    }
}

