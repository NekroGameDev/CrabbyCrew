using Assets.PixelCrew.Model.Definitions.Repositories.Items;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.Model.Definitions.Repositories
{
    [CreateAssetMenu(menuName = "Defs/ Potion", fileName = " Potion")]

    public class PotionRepository : DefRepository<PotionDef>
    {
        
    }
    [Serializable]

    public struct PotionDef : IHaveId
    {
        [InventoryId] [SerializeField] private string _id;
        [SerializeField] private Effect _effect;
        [SerializeField] private float _value;
        [SerializeField] private float _time;
        public string Id => _id;
        public Effect Effect => _effect;

        public float Value => _value;
        public float Time => _time;

    }
    public enum Effect
    {
        AddHp,
        SpeedUp
    }
}