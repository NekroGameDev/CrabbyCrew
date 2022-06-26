﻿using PixelCrew.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Assets.Prefabs.Creatures.PatricTheBoss.Bombs
{
    public class BombsController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _platforms;
        [SerializeField] private BombSequence[] _sequences;
        private Coroutine _coroutine;

        [ContextMenu("Start bombing")]

        public void StartBombing()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(BombingSequence());
        }

        private IEnumerator BombingSequence()
        {
            _platforms.ForEach(x => x.SetActive(false));
            foreach (var bombSequence in _sequences)
            {
                foreach ( var spawnComponent in bombSequence.Spawn)
                {
                    spawnComponent.Spawn();
                }

                yield return new WaitForSeconds(bombSequence.Delay);
            }

            _platforms.ForEach(x => x.SetActive(true));

            _coroutine = null;
        }

        [Serializable]

        public class BombSequence
        {
            [SerializeField] private SpawnComponent[] _bombPoints;
            [SerializeField] private float _delay;

            public SpawnComponent[] Spawn => _bombPoints;

            public float Delay => _delay;
        }
    }
}