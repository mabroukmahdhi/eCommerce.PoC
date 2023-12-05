// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Companies;

namespace SaarWorld.Views.Pages.Companies
{
    public partial class CompanyPage : ContentPage
    {
        public CompanyPage(CompanyViewService companyViewService)
        {
            InitializeComponent();
            this.BindingContext = companyViewService;
        }
    }
}