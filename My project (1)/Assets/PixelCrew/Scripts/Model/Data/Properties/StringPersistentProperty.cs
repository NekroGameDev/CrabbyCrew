using PixelCrew.Model.Data.Properties;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.Model.Data.Properties
{
    public class StringPersistentProperty : PrefsPersistenProperty<string>
    {
        public StringPersistentProperty(string defaultValue, string key) : base(defaultValue, key)
        {
            Init();
        }
        protected override void Write(string value)
        {
            PlayerPrefs.SetString(Key, value);
        }
        protected override string Read(string defaultValue)
        {
            return PlayerPrefs.GetString(Key, defaultValue);

        }


    }
}