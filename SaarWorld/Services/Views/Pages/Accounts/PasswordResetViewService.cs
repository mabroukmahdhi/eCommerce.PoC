// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Accounts;

namespace SaarWorld.Services.Views.Pages.Accounts
{
    public partial class PasswordResetViewService : BaseViewService
    {
        public PasswordResetViewService(ILocalizationService localizationService) :
            base(localizationService)
        {
        }
        #region labels
        [ObservableProperty]
        protected string forgotPasswordLabelText;

        [ObservableProperty]
        protected string emailLabelText;
        #endregion
        #region buttons
        [ObservableProperty]
        protected string sendEmailButton;
        #endregion
        #region placeholder
        [ObservableProperty]
        protected string emailPlaceholder;
        #endregion
        [RelayCommand]
        async void PasswordResetAsync()
        {

            await Shell.Current.GoToAsync(nameof(PasswordResetVerificationPage));

        }
        protected override void LocalizeTexts()
        {
            ForgotPasswordLabelText = GetLocalizedString("FORGET_PASSWORD");
            EmailLabelText = GetLocalizedString("EMAIL");
            SendEmailButton = GetLocalizedString("SEND_EMAIL");
            EmailPlaceholder = GetLocalizedString("EMAIL_PLACEHOLDER");
        }

    }
}

