using PixelCrew.PixelCrew.Scripts.Model.Definitions.Localization;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.Model.Definitions.Localization
{
    public abstract class AbstractLocalizeComponent : MonoBehaviour
    {
        protected virtual void Awake()
        {

            LocalizationManager.I.OnLocaleChanged += OnLocaleChanged;
            Localize();
        }

        private void OnLocaleChanged()
        {
            Localize();
        }

        protected abstract void Localize();
        

        private void OnDestroy()
        {
            LocalizationManager.I.OnLocaleChanged -= OnLocaleChanged;
        }
    }
}