using Assets.PixelCrew.Scripts.Model.Data.Properties;
using PixelCrew.PixelCrew.Scripts.UIscripts.Windows.Localization;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PixelCrew.PixelCrew.Scripts.Model.Definitions.Localization
{
    public class LocalizationManager 
    {
        public readonly static LocalizationManager I;

        private StringPersistentProperty _localeKey = new StringPersistentProperty("en", "localization/current");
        private Dictionary<string, string> _localization;


        public event Action OnLocaleChanged;
        public string LocaleKey => _localeKey.Value;

        static LocalizationManager()
        {
            I = new LocalizationManager();
        }

        public LocalizationManager()
        {
            LoadLocale(_localeKey.Value);
        }


    public string Localize(string key)
        {
            return _localization.TryGetValue(key, out var value) ? value :  $"%%%{key}%%%";
        }

        private void LoadLocale(string localeToLoad)
        {
            var def  = Resources.Load<LocalDef>($"Locales/{localeToLoad}");
            _localization = def.GetData();
            _localeKey.Value = localeToLoad;
            OnLocaleChanged?.Invoke();
        }

        public void SetLocale(string localeKey)
        {
            LoadLocale(localeKey);
        }
    }
}