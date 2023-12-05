// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using SaarWorld.Services.Foundations.Localizations;

namespace SaarWorld.Services.Views.Bases
{
    public abstract partial class BaseViewService : ObservableObject
    {
        private readonly ILocalizationService localizationService;

        public BaseViewService(ILocalizationService localizationService)
        {
            this.localizationService = localizationService;
            LocalizeTexts();
            this.CanEdit = true;
        }

        [ObservableProperty]
        protected bool isBusy;

        [ObservableProperty]
        protected string title;

        [ObservableProperty]
        protected bool canEdit;

        protected abstract void LocalizeTexts();

        protected virtual string GetLocalizedString(string key) =>
            this.localizationService[key];

        protected virtual async ValueTask DisplayError(string message)
        {
            var caption = GetLocalizedString("ERROR");

            await Application.Current.MainPage.DisplayAlert(caption, message, "OK");
        }

        protected virtual async ValueTask DisplayInfo(string message)
        {
            var caption = GetLocalizedString("INFO");

            await Application.Current.MainPage.DisplayAlert(caption, message, "OK");
        }

        protected void SetBusyStatus(bool busy)
        {
            this.IsBusy = busy;
            this.CanEdit = !busy;
        }
    }
}
