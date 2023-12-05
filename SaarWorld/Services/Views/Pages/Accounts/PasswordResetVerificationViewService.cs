// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SaarWorld.Models.PasswordResetVerificationRequests;
using SaarWorld.Models.Preferences;
using SaarWorld.Services.Foundations.Accounts;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Foundations.Preferences;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Accounts;

namespace SaarWorld.Services.Views.Pages.Accounts
{
    public partial class PasswordResetVerificationViewService : BaseViewService
    {
        private readonly IAccountService accountService;
        private readonly IPreferenceService preferenceService;

        public PasswordResetVerificationViewService(
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
        protected string forgotPasswordLabelText;

        [ObservableProperty]
        protected string verifyLabelText;
        [ObservableProperty]
        protected string number1LabelText;
        [ObservableProperty]
        protected string number2LabelText;
        [ObservableProperty]
        protected string number3LabelText;
        [ObservableProperty]
        protected string number4LabelText;
        [ObservableProperty]
        protected string number5LabelText;
        [ObservableProperty]
        protected string number6LabelText;
        #endregion
        #region buttons
        [ObservableProperty]
        protected string verifyButton;
        #endregion
        #region placeholder
        [ObservableProperty]
        protected string emailPlaceholder;
        #endregion
        #region data properties

        [ObservableProperty]
        protected int verifNumber1;

        [ObservableProperty]
        protected int verifNumber2;

        [ObservableProperty]
        protected int verifNumber3;

        [ObservableProperty]
        protected int verifNumber4;

        [ObservableProperty]
        protected int verifNumber5;

        [ObservableProperty]
        protected int verifNumber6;
        #endregion


        [RelayCommand]
        private async void PasswordResetVerificationAsync()
        {
            try
            {
                SetBusyStatus(true);

                var response = await this.accountService.PasswordResetVerificationAync(new PasswordResetVerificationRequest
                {
                    VerifNumber1 = VerifNumber1,
                    verifNumber2 = VerifNumber2,
                    VerifNumber3 = VerifNumber3,
                    VerifNumber4 = VerifNumber4,
                    VerifNumber5 = VerifNumber5,
                    VerifNumber6 = VerifNumber6,


                });

                this.preferenceService.AddPreference(new Preference
                {
                    Key = Preference.PreferenceTokenKey,
                    Value = response.AccessToken
                });

                await Shell.Current.GoToAsync(nameof(PasswordResetVerifiedPage));
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
            ForgotPasswordLabelText = GetLocalizedString("VERIFICATION");
            VerifyLabelText = GetLocalizedString("PLEASE CHECK YOUR EMAIL,WE HAVE SENT YOU A 6 DIGITS NUMBER FOR VERIFICATION");
            VerifyButton = GetLocalizedString("VERIFY");
            Number1LabelText = GetLocalizedString("VERIFICATIONNUMBER1");
            Number2LabelText = GetLocalizedString("VERIFICATIONNUMBER2");
            Number3LabelText = GetLocalizedString("VERIFICATIONNUMBER3");
            Number4LabelText = GetLocalizedString("VERIFICATIONNUMBER4");
            Number5LabelText = GetLocalizedString("VERIFICATIONNUMBER5");
            Number6LabelText = GetLocalizedString("VERIFICATIONNUMBER6");
        }
    }
}


