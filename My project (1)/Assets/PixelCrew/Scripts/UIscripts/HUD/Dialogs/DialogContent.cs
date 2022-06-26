﻿using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.Scripts.UIscripts.HUD.Dialogs
{
    public class DialogContent : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private Image _icon;

        public Text Text => _text;

        public void TrySetIcon(Sprite icon)
        {
            if (_icon != null)
                _icon.sprite = icon;
        }
    }
}