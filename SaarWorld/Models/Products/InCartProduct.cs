// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SaarWorld.Models.Messengings.Refreshs;

namespace SaarWorld.Models.Products
{
    public partial class InCartProduct : ObservableObject
    {
        [ObservableProperty]
        private Product cartProduct;

        [ObservableProperty]
        private int count;

        [ObservableProperty]
        protected bool buyButtonVisible = true;

        [ObservableProperty]
        protected bool countButtonsVisible = false;

        [ObservableProperty]
        protected string currency;

        public decimal Total => Count * CartProduct.Price;

        [RelayCommand]
        protected void Buy()
        {
            Count++;
            BuyButtonVisible = false;
            CountButtonsVisible = true;
            Notify();
        }

        [RelayCommand]
        protected void Inc()
        {
            if (Count < 15)
            {
                Count++;
                BuyButtonVisible = Count <= 0;
                CountButtonsVisible = Count > 0;
                Notify();
            }
        }

        [RelayCommand]
        protected void Dec()
        {
            if (Count > 0)
            {
                Count--;
                BuyButtonVisible = Count <= 0;
                CountButtonsVisible = Count > 0;
                Notify();
            }
        }

        void Notify()
        {
            WeakReferenceMessenger.Default.Send(new RefreshMessage(true));
        }
    }
}
