using PixelCrew.Components.Audio;
using System;
using UnityEngine;

namespace PixelCrew.Scripts.Utils
{
    public class AudioUtils 
    {
        public const string SfxSourceTag = "SfxAudioSource";
        public static AudioSource FindSfxSource()
        {
           return GameObject.FindWithTag(SfxSourceTag).GetComponent<AudioSource>();
        }
    }
}
