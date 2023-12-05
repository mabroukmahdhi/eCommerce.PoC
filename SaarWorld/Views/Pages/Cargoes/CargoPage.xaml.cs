// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Cargoes;

namespace SaarWorld.Views.Pages.Cargoes
{
    public partial class CargoPage : ContentPage
    {
        public CargoPage(CargoViewService cargoViewService)
        {
            InitializeComponent();
            BindingContext = cargoViewService;
        }
    }
}