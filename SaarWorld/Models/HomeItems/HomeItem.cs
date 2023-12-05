// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

namespace SaarWorld.Models.HomeItems
{
    public class HomeItem
    {
        public HomeItemType Type { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string NavigatesTo { get; set; }
    }
}
