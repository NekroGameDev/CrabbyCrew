﻿using Assets.PixelCrew.Model.Definitions.Repositories.Items;
using System;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.Model.Definitions.Repositories
{
    [CreateAssetMenu(menuName = "Defs/Throwable", fileName = "Throwable")]
    public class ThrowableRepository : DefRepository<ThrowableDef>
    {
    }
    [Serializable]

    public struct ThrowableDef : IHaveId
    {
        [InventoryId][SerializeField] private string _id;
        [SerializeField] private GameObject _projectile;

        public string Id => _id;
        public GameObject Projectile => _projectile;
    }
}