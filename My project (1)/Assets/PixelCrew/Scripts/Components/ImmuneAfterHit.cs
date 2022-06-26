using PixelCrew.Components;
using PixelCrew.Scripts.Utils.Disposables;
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.Components
{
    [RequireComponent(typeof(HealthComponent))]
    public class ImmuneAfterHit : MonoBehaviour
    {
        [SerializeField] private float _immuneTime;
        private HealthComponent _health;
        private Coroutine _coroutine;
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private void Awake()
        {
            _health = GetComponent<HealthComponent>();
            _trash.Retain(_health._onDamage.Subscribe(OnDamage));
        }

        private void OnDamage()
        {
            TryStop();
            if(_immuneTime > 0)
            {
                _coroutine = StartCoroutine(MakeImmune());
            }
        }

        private void TryStop()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator MakeImmune()
        {
            _health.Immune.Retain(this);
            yield return new WaitForSeconds(_immuneTime);
            _health.Immune.Release(this);
        }

        private void OnDestroy()
        {
            TryStop();
            _trash.Dispose();
        }
    }
}