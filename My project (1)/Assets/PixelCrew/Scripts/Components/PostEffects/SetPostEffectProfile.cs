﻿using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.PixelCrew.Scripts.Components.PostEffects
{
    public class SetPostEffectProfile : MonoBehaviour
    {
        [SerializeField] private VolumeProfile _profile;
        public void Set()
        {
            var volumes = FindObjectsOfType<Volume>();
            foreach (var volume in volumes)
            {
                if (!volume.isGlobal) continue;

                volume.profile = _profile;
                break;
            }
        }
    }
}