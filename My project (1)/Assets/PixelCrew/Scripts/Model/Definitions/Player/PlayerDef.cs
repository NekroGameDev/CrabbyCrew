using Assets.PixelCrew.Scripts.Model.Definitions.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.PixelCrew.Scripts.Model.Definitions.Player.StatDef;

namespace PixelCrew.Model.Definitions.Editor.Player
{
    [CreateAssetMenu(menuName = "Defs/PlayerDef", fileName = "PlayerDef")]
    public class PlayerDef : ScriptableObject
    {
        [SerializeField] private int _inventorySize;
        [SerializeField] private int _maxHealth;
        [SerializeField] private StatDef[] _stats;

        public int InventorySize => _inventorySize;


        public StatDef[] Stats => _stats;

        public StatDef GetStat(StatId id)
        {
            foreach (var statDef in _stats)
            {
                if(statDef.ID == id)
                {
                    return statDef;
                }
            }

            return default;
        }
    }
}
