// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Homes;

namespace SaarWorld.Services.Views.Pages.Accounts
{
    public partial class AccountCreatedViewService : BaseViewService
    {
        public AccountCreatedViewService(
            ILocalizationService localizationService)

           : base(localizationService)
        {

        }
        #region labels
        [ObservableProperty]
        protected string startLabelText;

        [ObservableProperty]
        protected string accountLabelText;
        #endregion
        #region buttons
        [ObservableProperty]
        protected string startButtonText;
        #endregion

        [RelayCommand]
        async void GoToHomeAsync()
        {

            await Shell.Current.GoToAsync(nameof(HomePage));

        }
        protected override void LocalizeTexts()
        {
            AccountLabelText = GetLocalizedString("YOUR_ACCOUNT_HAS_BEEN_CREATED_SUCCESSFULY");
            StartLabelText = GetLocalizedString("START_BROWSING_OUR_OFFERS_NOW");
            StartButtonText = GetLocalizedString("START NOW");
        }
    }
}

