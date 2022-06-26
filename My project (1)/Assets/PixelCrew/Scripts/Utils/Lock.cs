using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.Utils
{
    public class Lock 
    {
        private readonly List<object> _retained = new List<object>();

        public void Retain(object item)
        {
            _retained.Add(item);
        }

        public void Release(object item)
        {
            _retained.Remove(item);
        }

        public bool IsLocked => _retained.Count > 0;
    }
}