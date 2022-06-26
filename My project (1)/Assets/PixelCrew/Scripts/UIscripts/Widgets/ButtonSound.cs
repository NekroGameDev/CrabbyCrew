using PixelCrew.Components.Audio;
using PixelCrew.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PixelCrew.UIscripts.Widgets
{
    public class ButtonSound : MonoBehaviour, IPointerClickHandler
    {

        [SerializeField] private AudioClip _audioClip;

        private AudioSource _source;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_source == null)
                _source = AudioUtils.FindSfxSource();
            
            _source.PlayOneShot(_audioClip);
        }
    }
}
