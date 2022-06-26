﻿using PixelCrew.Model;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.PixelCrew.Assets.Prefabs.Creatures.Features
{
    public class HeroFlashLight : MonoBehaviour
    {
        [SerializeField] private float _consumePerSecond;
        [SerializeField] private Light2D _light;

        private GameSession _session;
        private float _defaultIntensity;
        private void Start()
        {
            _session = GameSession.Instance;
            _defaultIntensity = _light.intensity;
        }

        private void Update()
        {
            var consumed = Time.deltaTime * _consumePerSecond;
            var currentValue = _session.Data.Fuel.Value;
            var nextValue = currentValue - consumed;
            nextValue = Mathf.Max(nextValue, 0);
            _session.Data.Fuel.Value = nextValue;

            var progress = Mathf.Clamp( nextValue / 20, 0,  1);
            _light.intensity = _defaultIntensity * progress;
        }
    }
}