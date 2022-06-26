using PixelCrew.PixelCrew.Scripts.Model.Definitions.Localization;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.Utils
{
    public static class LocalizationExtensions 
    {
        public static string Localize( this string key)
        {
            return LocalizationManager.I.Localize(key);
        }
    }
}