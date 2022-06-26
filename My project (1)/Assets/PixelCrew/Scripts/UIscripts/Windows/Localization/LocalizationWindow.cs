﻿using Assets.PixelCrew.Scripts.UIscripts.Widgets;
using PixelCrew.PixelCrew.Scripts.Model.Definitions.Localization;
using PixelCrew.PixelCrew.Scripts.UIscripts.Windows.Localization;
using PixelCrew.UI;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.UIscripts.Windows.Localization
{
    public class LocalizationWindow : AnimatedWindow
    {
        [SerializeField] private Transform _container;
        [SerializeField] private LocaleItemWidget _prefab;

        private DataGroup<LocaleInfo, LocaleItemWidget> _dataGroup;
        private string[] _supportedLocales = new[] { "en", "ru" };
        protected override void Start()
        {
            base.Start();
            _dataGroup = new DataGroup<LocaleInfo, LocaleItemWidget>(_prefab, _container);
            _dataGroup.SetData(ComposeData());

        }
        
        private List<LocaleInfo> ComposeData()
        {
            var data = new List<LocaleInfo>();
            foreach (var locale in _supportedLocales)
            {
                data.Add(new LocaleInfo { LocaleId = locale });
            }
            return data;
        }

        public void OnSelected(string selectedLocale)
        {
            LocalizationManager.I.SetLocale(selectedLocale);
        }
    }
}