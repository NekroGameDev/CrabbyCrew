using Assets.PixelCrew.Scripts.Utils;
using PixelCrew.Components;
using PixelCrew.Scripts.UIscripts.Widgets;
using PixelCrew.Scripts.Utils.Disposables;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.UIscripts.Widgets
{
    public class BossHpWidget : MonoBehaviour
    {
        [SerializeField] private HealthComponent _health;
        [SerializeField] private ProgressBarWidget _hpBar;
        [SerializeField] private CanvasGroup _canvas;

        private readonly CompositeDisposable _trash = new CompositeDisposable();
        private float _maxHealth;
        private void Start()
        {
            _maxHealth = _health.Health;
            _trash.Retain(_health._onChange.Subscribe(OnHpChanged));
            _trash.Retain(_health._onDie.Subscribe(HideUI));

        }

        [ContextMenu("Show")]
        public void ShowUI()
        {
            this.LerpAnimated(0, 1, 1, SetAlpha);
        }

        private void SetAlpha(float alpha)
        {
            _canvas.alpha = alpha;
        }

        [ContextMenu("Hide")]

        private void HideUI()
        {
            this.LerpAnimated(1, 0, 1, SetAlpha);

        }

        private void OnHpChanged(int hp)
        {
            _hpBar.SetProgress(hp / _maxHealth);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}