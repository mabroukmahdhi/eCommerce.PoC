// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SaarWorld.Models.Cargos;
using SaarWorld.Services.Foundations.Cargoes;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Views.Bases;

namespace SaarWorld.Services.Views.Pages.Cargoes
{
    public partial class CargoViewService : BaseViewService
    {
        private readonly ICargoService cargoService;

        public CargoViewService(ILocalizationService localizationService,
            ICargoService cargoService)
            : base(localizationService)
        {
            this.cargoService = cargoService;
            GetCargos();
        }


        #region label
        [ObservableProperty]
        protected string chooseCargoLabelText;
        [ObservableProperty]
        protected string searchLabelText;
        #endregion
        #region
        [ObservableProperty]
        protected string searchPlaceholder;
        #endregion
        #region data properties
        [ObservableProperty]
        protected ObservableCollection<Cargo> cargosList = new ObservableCollection<Cargo>();
        #endregion
        #region data proporties
        [ObservableProperty]
        protected string name;
        [ObservableProperty]
        protected string description;
        [ObservableProperty]
        protected string imageUrl;
        [ObservableProperty]
        protected int size;
        #endregion

        public async void GetCargos()
        {
            try
            {
                IsBusy = true;

                List<Cargo> cargos = await cargoService.GetCargosAsync();
                CargosList = new ObservableCollection<Cargo>(cargos);
            }
            catch (Exception exception)
            {
                await DisplayError(exception.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void LocalizeTexts()
        {
            ChooseCargoLabelText = GetLocalizedString("CHOOSE_CARGO");
            SearchLabelText = GetLocalizedString("SEARCH");
            SearchPlaceholder = GetLocalizedString("SEARCH_PLACEHOLDER");
        }
    }
}