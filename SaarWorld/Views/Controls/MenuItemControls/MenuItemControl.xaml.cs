// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Models.HomeItems;

namespace SaarWorld.Views.Controls.MenuItemControls
{
    public partial class MenuItemControl : Border
    {
        public MenuItemControl() =>
            InitializeComponent();

        #region Icon
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(
               propertyName: nameof(Icon),
               returnType: typeof(ImageSource),
               declaringType: typeof(MenuItemControl),
               defaultValue: default(ImageSource),
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: OnIconChanged);

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        private static void OnIconChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            var icon =
                (bindable as MenuItemControl).IconImage;

            icon.Source = (ImageSource)newValue;
        }
        #endregion

        #region ItemType
        public static readonly BindableProperty ItemTypeProperty =
            BindableProperty.Create(
               propertyName: nameof(ItemType),
               returnType: typeof(HomeItemType),
               declaringType: typeof(MenuItemControl),
               defaultValue: HomeItemType.Cargo,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: OnItemTypeChanged);

        public HomeItemType ItemType
        {
            get => (HomeItemType)GetValue(ItemTypeProperty);
            set => SetValue(ItemTypeProperty, value);
        }

        private static void OnItemTypeChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            //var recognizer =
            //    (bindable as MenuItemControl).tapRecognizer;

            //recognizer.CommandParameter = (HomeItemType)newValue;
        }
        #endregion

        #region Title
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(
               propertyName: nameof(Title),
               returnType: typeof(string),
               declaringType: typeof(MenuItemControl),
               defaultValue: "Change me",
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: OnTitleChanged);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        private static void OnTitleChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            var title =
                (bindable as MenuItemControl).TitleLabel;

            title.Text = (string)newValue;
        }
        #endregion
    }
}