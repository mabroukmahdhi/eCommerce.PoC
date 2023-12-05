// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using SaarWorld.Brokers.Preferences;
using SaarWorld.Models.Preferences;

namespace SaarWorld.Services.Foundations.Preferences
{
    public class PreferenceService : IPreferenceService
    {
        private readonly IPreferenceBroker preferenceBroker;

        public PreferenceService(IPreferenceBroker preferenceBroker) =>
            this.preferenceBroker = preferenceBroker;

        public bool CheckExistance(string key) =>
             this.preferenceBroker.PreferenceExists(key);

        public Preference RetrievePreferenceByKey(string key) =>
            this.preferenceBroker.SelectPreferenceByKey(key);

        public void AddPreference(Preference preference) =>
            this.preferenceBroker.InsertPreference(preference);

        public void ModifyPreferenceByKey(Preference preference) =>
             this.preferenceBroker.UpdatePreferenceByKey(preference);

        public void RemovePreferenceByKey(string key) =>
             this.preferenceBroker.DeletePreferenceByKey(key);
    }
}
