// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls;
using SaarWorld.Models.Messengings.Companies;
using SaarWorld.Models.Messengings.Refreshs;
using SaarWorld.Models.Products;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Views.Bases;
using SaarWorld.Views.Pages.Orders;

namespace SaarWorld.Services.Views.Pages.Products;

public partial class ProductViewService : BaseViewService
{
    public ProductViewService(ILocalizationService localizationService)
        : base(localizationService)
    {
        WeakReferenceMessenger.Default.Register<CompanyMessage>(this, OnProductDetailsReceived);
        WeakReferenceMessenger.Default.Register<RefreshMessage>(this, OnRefreshRequested);
    }

    #region  label
    [ObservableProperty]
    protected string productsLabelText;
    [ObservableProperty]
    protected string searchLabelText;
    #endregion

    #region placeholder
    [ObservableProperty]
    protected string searchPlaceholder;
    #endregion

    #region dataproporties
    [ObservableProperty]
    protected ObservableCollection<InCartProduct> products;
    [ObservableProperty]
    protected string name;
    [ObservableProperty]
    protected string description;
    [ObservableProperty]
    protected string logo;
    [ObservableProperty]
    protected decimal totalPrice;

    [ObservableProperty]
    protected string currency;

    // public decimal TotalPrice { get => Products?.Where(p => p.Count > 0)?.Sum(p => p.Count * p.Product.Price); }
    #endregion 

    private void OnProductDetailsReceived(
        object recipient,
        CompanyMessage message)
    {
        var company = message?.Value?.Company;

        Currency = company?.CurrencySymbol?.ToUpperInvariant() ?? string.Empty;

        var companyProducts = company?.Products
            .Select(p => new InCartProduct()
            {
                CartProduct = p,
                Currency = Currency
            });

        Products = new ObservableCollection<InCartProduct>(
            collection: companyProducts ?? new List<InCartProduct>());
    }

    private void OnRefreshRequested(object recipient, RefreshMessage message)
    {
        TotalPrice = Products?.Where(p => p.Count > 0)?.Sum(p => p.Total) ?? 0;
    }

    [RelayCommand]
    private async void ConfirmOrder()
    {
        await Shell.Current.GoToAsync(
              state: nameof(OrderConfirmedPage),
              animate: true);
    }


    protected override void LocalizeTexts()
    {
        ProductsLabelText = GetLocalizedString("COMPANIES");
        SearchLabelText = GetLocalizedString("SEARCH");
        SearchPlaceholder = GetLocalizedString("SEARCH_PLACEHOLDER");

    }
}