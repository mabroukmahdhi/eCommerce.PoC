// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

namespace SaarWorld.Models.Preferences
{
    public class Preference
    {
        #region constants
        public const string PreferenceTokenKey = "ACCESS_TOKEN";
        #endregion

        public string Key { get; set; }
        public string Value { get; set; }
    }
}