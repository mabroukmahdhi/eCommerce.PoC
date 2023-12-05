// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using CommunityToolkit.Mvvm.ComponentModel;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Views.Bases;

namespace SaarWorld.Services.Views.Pages.Locations
{
    public partial class CurrentLocationViewService : BaseViewService
    {
        private readonly ILocationService locationService;
        public CurrentLocationViewService(ILocalizationService localizationService,
            ILocationService locationService)
            : base(localizationService)
        {
        }
        #region label
        [ObservableProperty]
        protected string currentLocationPageLabelText;
        [ObservableProperty]
        protected string address;
        #endregion
        //private async ValueTask<string> ConvertCoordinatesToAddress(double latitude, double longitude)
        //{
        //    var locations = await this.locationService.ReverseGeoLocationAsync(latitude, longitude);
        //    var placemark = locations?.FirstOrDefault();

        //    if (placemark != null)
        //    {
        //        return $"{placemark.SubThoroughfare} {placemark.Thoroughfare}, {placemark.Locality}, {placemark.CountryName}";
        //    }

        //    return "Address not found";
        //}
        protected override void LocalizeTexts()
        {
            CurrentLocationPageLabelText = GetLocalizedString("CURRENT_LOCATION_PAGE");

        }
    }
}

