using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _power;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

    }



}
