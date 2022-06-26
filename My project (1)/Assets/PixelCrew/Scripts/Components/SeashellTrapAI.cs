using PixelCrew.Components;
using PixelCrew.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Creatures
{
    public class SeashellTrapAI : MonoBehaviour
    {
        [SerializeField] private LayerCheck _vision;

        [Header ("Meele")]
        [SerializeField] private CheckCircleOverlap _meeleAttack;
        [SerializeField] private LayerCheck _meleeCanAttack;
        [SerializeField] private Cooldown _meleeCooldown;

        [Header("Range")]
        [SerializeField] private SpawnComponent _rangeAttack;
        [SerializeField] private Cooldown _rangeCooldown;

        private static readonly int Meele = Animator.StringToHash("melee");
        private static readonly int Range = Animator.StringToHash("range");

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void Update()
        {
            if (_vision.IsTouchingLayer)
            {
                if (_meleeCanAttack.IsTouchingLayer)
                {
                    if (_meleeCooldown.IsReady)
                        MeleeAttack();
                    return;
                }
                if (_rangeCooldown.IsReady)
                    RangeAttack();
            }
        }

        private void RangeAttack()
        {
            _rangeCooldown.Reset();
            _animator.SetTrigger(Range);

        }

        private void MeleeAttack()
        {
            _meleeCooldown.Reset();
            _animator.SetTrigger(Meele);
        }

        public void OnMeleeAttack()
        {
            _meeleAttack.Check();
        }
        public void OnRangeAttack()
        {
            _rangeAttack.Spawn();
        }
    }

}


