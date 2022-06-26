using Assets.PixelCrew.Scripts.Utils;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] public UnityEvent _onDamage;
        [SerializeField] public UnityEvent _onDie;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] public HealthChange _onChange;
        private Lock _immune = new Lock();

        public int Health => _health;

        public Lock Immune => _immune;

        public void ModifyHealth(int healthDelta)
        {
            if (healthDelta < 0 && Immune.IsLocked) return;
            if (_health <= 0) return;
            _health += healthDelta;

            _onChange?.Invoke(_health);
          

            if (healthDelta < 0)
            {
                _onDamage?.Invoke();
            }

            if (healthDelta > 0)
            {
                _onHeal?.Invoke();
            }

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }

        }

#if UNITY_EDITOR
        [ContextMenu("Update Health")]

        private void UpdateHealth()
        {
            _onChange?.Invoke(_health);
        }
#endif

        public void SetHealth(int health)
        {
            _health = health;
        }

        private void OnDestroy()
        {
            _onDie.RemoveAllListeners();
        }

        [Serializable]
        public class HealthChange : UnityEvent<int>
        {

        }
    }

}