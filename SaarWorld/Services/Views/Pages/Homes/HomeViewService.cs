// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SaarWorld.Models.HomeItems;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Cargoes;
using SaarWorld.Views.Pages.ComingSoons;
using SaarWorld.Views.Pages.Companies;
using SaarWorld.Views.Pages.Details;

namespace SaarWorld.Services.Views.Pages.Homes
{
    public partial class HomeViewService : BaseViewService
    {
        public HomeViewService(ILocalizationService localizationService)
            : base(localizationService)
        {

            #region set collection
            Items = new ObservableCollection<HomeItem>
            {new HomeItem()
                {
                    Type=HomeItemType.Relocate,
                    Icon="relocate.svg",
                    Title =GetLocalizedString("RELOCATE"),
                    NavigatesTo =nameof(DeliveryDetailsPage),
                },
                new HomeItem()
                {
                    Type=HomeItemType.Cargo,
                    Icon="truck.png",
                    Title =GetLocalizedString("CARGO"),
                    NavigatesTo =nameof(CargoPage),
                },
                new HomeItem()
                {
                    Type=HomeItemType.Delivery ,
                    Icon="img_delivery.gif",
                    Title =GetLocalizedString("DELIVERY"),
                    NavigatesTo =nameof(CompanyPage)
                },
                new HomeItem()
                {
                    Type=HomeItemType.AirShipment,
                    Icon="airplane.png",
                    Title =GetLocalizedString("AIR_FREIGHT"),
                    NavigatesTo =nameof(ComingSoonPage)
                },
                new HomeItem()
                {
                    Type=HomeItemType.SeaShipment,
                    Icon="boat.png",
                    Title =GetLocalizedString("SEA_FREIGHT"),
                    NavigatesTo =nameof(ComingSoonPage)
                },
                new HomeItem()
                {
                    Type=HomeItemType.Clearance,
                    Icon="paper.png",
                    Title =GetLocalizedString("CLEARANCE"),
                   NavigatesTo =nameof(ComingSoonPage)
                },
                new HomeItem()
                {
                    Type=HomeItemType.Tracking,
                    Icon="ic_tracking.png",
                    Title =GetLocalizedString("TRACKING"),
                    NavigatesTo =nameof(ComingSoonPage)
                }
            };
            #endregion
        }

        #region properties
        [ObservableProperty]
        private ObservableCollection<HomeItem> items;

        [ObservableProperty]
        private HomeItem selectedHomeItem;
        #endregion

        #region commands
        [RelayCommand]
        async void ItemSelected(HomeItem homeItem)
        {
            if (SelectedHomeItem == null)
                return;

            await Shell.Current.GoToAsync(
                state: SelectedHomeItem.NavigatesTo,
                animate: true);

            SelectedHomeItem = null;

        }
        #endregion

        protected override void LocalizeTexts()
        { }
    }
}

