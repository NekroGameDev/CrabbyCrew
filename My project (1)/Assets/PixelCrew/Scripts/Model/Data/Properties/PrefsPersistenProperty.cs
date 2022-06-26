using PixelCrew.Model.Data.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Model.Data.Properties
{
    public abstract class PrefsPersistenProperty<TPropertyType> : PersistentProperty<TPropertyType>
    {
        protected string Key;
        protected PrefsPersistenProperty(TPropertyType defaultValue, string key) : base(defaultValue)
        {
            Key = key;
        }

    }
}
