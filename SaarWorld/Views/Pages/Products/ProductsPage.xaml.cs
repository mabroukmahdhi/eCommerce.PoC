// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Products;

namespace SaarWorld.Views.Pages.Products;

public partial class ProductsPage : ContentPage
{
    public ProductsPage(ProductViewService productViewService)
    {
        InitializeComponent();
        this.BindingContext = productViewService;
    }
}