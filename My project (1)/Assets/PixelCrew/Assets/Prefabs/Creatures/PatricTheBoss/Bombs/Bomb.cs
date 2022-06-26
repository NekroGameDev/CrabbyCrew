﻿using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.PixelCrew.Assets.Prefabs.Creatures.PatricTheBoss.Bombs
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _ttl;
        [SerializeField] private UnityEvent _onDetonate;

        private Coroutine _coroutine;
        private void OnEnable()
        {
            TryStop();
            _coroutine = StartCoroutine(WaitAndDetonate());
        }

        private IEnumerator WaitAndDetonate()
        {
            yield return new WaitForSeconds(_ttl);
            Detonate();
            _coroutine = null;
        }

        public void Detonate()
        {
            _onDetonate?.Invoke();
        }

        private void OnDisable()
        {
            TryStop();
        }

        private void TryStop()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}