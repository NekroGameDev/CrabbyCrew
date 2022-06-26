using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PixelCrew.Components.ProbabilityDropComponent;

namespace PixelCrew.Copmonents
{
    public class GoContainerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] _gos;
        [SerializeField] private DropEvent _onDrop;

        public void Drop()
        {
            _onDrop.Invoke(_gos);
        }
    }
}


