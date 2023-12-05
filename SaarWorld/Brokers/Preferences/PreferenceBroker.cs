// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using SaarWorld.Models.Preferences;

namespace SaarWorld.Brokers.Preferences
{
    public class PreferenceBroker : IPreferenceBroker
    {
        public void InsertPreference(Preference preference) =>
            Microsoft.Maui.Storage.Preferences.Set(
                key: preference.Key,
                value: preference.Value);

        public Preference SelectPreferenceByKey(string key)
        {
            var value =
                  Microsoft.Maui.Storage.Preferences.Get(
                      key: key,
                      defaultValue: null);

            return new Preference
            {
                Key = key,
                Value = value
            };
        }

        public void UpdatePreferenceByKey(Preference preference)
        {
            DeletePreferenceByKey(preference.Key);
            InsertPreference(preference);
        }

        public void DeletePreferenceByKey(string key) =>
            Microsoft.Maui.Storage.Preferences.Remove(key);

        public bool PreferenceExists(string key)
        {
            var selected = SelectPreferenceByKey(key);

            return selected.Value != null;
        }
    }
}