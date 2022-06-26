using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew
{


    public class LayerCheck : MonoBehaviour // Скрипт для проверки соприкосновения объекта со слоем Ground
    {
        [SerializeField] protected LayerMask _layer;
        [SerializeField] protected bool _isTouchingLayer;
        public bool IsTouchingLayer => _isTouchingLayer;
    }

}