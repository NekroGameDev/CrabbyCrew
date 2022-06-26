using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Creatures
{
    public class PlatformPatrol : Patrol
    {
        [SerializeField] private LayerCheck _groundCheck;
        [SerializeField] private LayerCheck _obstacleCheck;
        [SerializeField] private int _direction;
        [SerializeField] private OnChangeDirection _onChangeDirection;

        public override IEnumerator DoPatrol()
        {
            while (enabled)
            {
                if (_groundCheck.IsTouchingLayer && !_obstacleCheck.IsTouchingLayer)
                {
                    _onChangeDirection?.Invoke(new Vector2(_direction, 0));
                }

                else
                {
                    _direction = -_direction;
                    _onChangeDirection?.Invoke(new Vector2(_direction, 0));
                }
                yield return null;
            }
        }
        [Serializable]

        public class OnChangeDirection : UnityEvent<Vector2>
        {

        }
    }
    
}

