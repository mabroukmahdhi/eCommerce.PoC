// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Force.DeepCloner;
using Microsoft.Maui.Controls;
using SaarWorld.Models.Companies;
using SaarWorld.Models.Messengings.Companies;
using SaarWorld.Services.Foundations.Companies;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Products;

namespace SaarWorld.Services.Views.Pages.Companies;

public partial class CompanyViewService : BaseViewService

{
    private readonly ICompanyService companyService;

    public CompanyViewService(
        ILocalizationService localizationService,
        ICompanyService companyService)
        : base(localizationService)
    {
        this.companyService = companyService;
        GetCompanies();
    }

    #region  label
    [ObservableProperty]
    protected string companiesLabelText;
    [ObservableProperty]
    protected string searchLabelText;
    #endregion
    #region placeholder
    [ObservableProperty]
    protected string searchPlaceholder;
    #endregion
    #region dataproporties
    [ObservableProperty]
    protected ObservableCollection<Company> companies = new ObservableCollection<Company>();
    [ObservableProperty]
    protected string name;
    [ObservableProperty]
    protected string description;
    [ObservableProperty]
    protected string logo;

    [ObservableProperty]
    private Company selectedCompany;
    #endregion


    [RelayCommand]
    async void CompanySelected(Company company)
    {
        if (SelectedCompany == null)
            return;

        await Shell.Current.GoToAsync(
               state: nameof(ProductsPage),
               animate: true);

        WeakReferenceMessenger.Default.Send(new CompanyMessage(new CompanyToProductInfo()
        {
            Company = SelectedCompany.DeepClone()
        }));

        SelectedCompany = null;
    }

    public async void GetCompanies()
    {
        try
        {
            IsBusy = true;

            List<Company> company = await this.companyService.GetCompaniesAsync();
            Companies = new ObservableCollection<Company>(company);
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
        CompaniesLabelText = GetLocalizedString("COMPANIES");
        SearchLabelText = GetLocalizedString("SEARCH");
        SearchPlaceholder = GetLocalizedString("SEARCH_PLACEHOLDER");

    }
}