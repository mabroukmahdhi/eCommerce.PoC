// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using SaarWorld.Models.Preferences;

namespace SaarWorld.Brokers.Preferences
{
    public interface IPreferenceBroker
    {
        void InsertPreference(Preference preference);
        Preference SelectPreferenceByKey(string key);
        void UpdatePreferenceByKey(Preference preference);
        void DeletePreferenceByKey(string key);
        bool PreferenceExists(string key);
    }
}