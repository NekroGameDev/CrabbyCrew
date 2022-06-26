using Assets.PixelCrew.Scripts.Model.Data;
using Assets.PixelCrew.Scripts.Model.Data.Properties;
using PixelCrew.Model.Data;
using PixelCrew.Scripts.Model.Data.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Model
{
    [Serializable]
    public class PlayerData 
    {
        [SerializeField] private InventoryData _inventory;

        public IntProperty Hp = new IntProperty();
        public FloatProperty Fuel = new FloatProperty();
        public PerksData Perks = new PerksData();
        public LevelData Levels = new LevelData();

        public InventoryData Inventory => _inventory;

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this); // перевод файлов в формат Json
            return JsonUtility.FromJson<PlayerData>(json); // чтение формата json
        }
    }
}


