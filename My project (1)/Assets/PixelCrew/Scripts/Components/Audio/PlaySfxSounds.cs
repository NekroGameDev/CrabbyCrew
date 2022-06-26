using PixelCrew.Scripts.Utils;
using System;
using UnityEngine;

namespace Assets.Scripts.Components.Audio
{
    public class PlaySfxSounds : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;
        private AudioSource _source;

        public void Play()
        {
            if (_source == null)
                _source = AudioUtils.FindSfxSource();

            _source.PlayOneShot(_clip);
        }
    }
}
