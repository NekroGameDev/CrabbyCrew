using Assets.PixelCrew.Scripts.Model.Definitions.Repositories;
using PixelCrew.Model;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.Scripts.UIscripts.HUD
{
    public class CurrentPerkWidget : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _cooldownImage;

        private GameSession _session;

        private void Start()
        {
            _session = GameSession.Instance;
        }
        public void Set(PerkDef perkDef)
        {
            _icon.sprite = perkDef.Icon;
        }

        private void Update()
        {
            var cooldown = _session.PerksModel.Cooldown;
            _cooldownImage.fillAmount = cooldown.RemaininTime / cooldown.Value;
        }
    }
}