// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using SaarWorld.Models.Preferences;

namespace SaarWorld.Services.Foundations.Preferences
{
    public interface IPreferenceService
    {
        void AddPreference(Preference preference);
        Preference RetrievePreferenceByKey(string key);
        void ModifyPreferenceByKey(Preference preference);
        void RemovePreferenceByKey(string key);
        bool CheckExistance(string key);
    }
}
