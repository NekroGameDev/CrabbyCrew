using PixelCrew.Components;
using PixelCrew.Components.Audio;
using PixelCrew.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace PixelCrew.Creatures
{
    public class Creature : MonoBehaviour
    {
        [Header("Params")]
        [SerializeField] private bool _invertScale;
        [SerializeField] private float _speed;
        [SerializeField] protected float _jumpSpeed;
        [SerializeField] private float _damageVelocity;

        [Header("Checkers")]
        [SerializeField] protected LayerMask _groundLayer;
        [SerializeField] private LayerCheck _groundCheck;
        [SerializeField] private CheckCircleOverlap _attackRange;
        [SerializeField] protected SpawnListComponent _particles;


        protected Rigidbody2D Rigidbody;
        protected Vector2 Direction;
        protected Animator Animator;
        protected PlaySoundsComponent Sounds;
        protected bool IsGrounded;
        protected bool _isJumping;

        private static readonly int IsGroundKey = Animator.StringToHash("is-ground"); // Добавляет статичную переменную для уменьшения нагрузки на память
        private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");
        private static readonly int IsRunning = Animator.StringToHash("is-running");
        private static readonly int Hit = Animator.StringToHash("hit");
        private static readonly int AttackKey = Animator.StringToHash("attack");

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();  // Получаем доступ к RB2D
            Animator = GetComponent<Animator>(); // Получаем доступ к Аниматору
            Sounds = GetComponent<PlaySoundsComponent>();
        }
        public void SetDirection(Vector2 direction) // Устанвливает направление 
        {
            Direction = direction; // Направление 
        }
        protected virtual void Update()
        {
            
                IsGrounded = _groundCheck.IsTouchingLayer;
            
        }
        private void FixedUpdate() // Процесc запускается каждый кадр
        {
            var xVelocity = Direction.x * CalculateSpeed();
            var yVelocity = CalculateYVelocity();
            Rigidbody.velocity = new Vector2(xVelocity, yVelocity);


            Animator.SetBool(IsGroundKey, IsGrounded);
            Animator.SetFloat(VerticalVelocity, Rigidbody.velocity.y);
            Animator.SetBool(IsRunning, Direction.x != 0); // Если движение не равно 0, значит мы бежим

            UpdateSpriteDirection(Direction);
        }

        protected virtual float CalculateSpeed()
        {
            return _speed;
        }
        protected virtual float CalculateYVelocity()
        {

            var yVelocity = Rigidbody.velocity.y;
            var isJumpPressing = Direction.y > 0;

            if (IsGrounded)
            {
                _isJumping = false;
            }



            if (isJumpPressing)
            {
                _isJumping = true;


                var isFalling = Rigidbody.velocity.y <= 0.001f;
                yVelocity = isFalling ? CalculateJumpVelocity(yVelocity) : yVelocity;
            }
            else if (Rigidbody.velocity.y > 0 && _isJumping)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        protected virtual float CalculateJumpVelocity(float yVelocity)
        {

            if (IsGrounded)
            {
                yVelocity = _jumpSpeed;
                DoJumpVfx();
            }

            return yVelocity;
        }

        protected void DoJumpVfx()
        {
            //Profiler.BeginSample("JumpVFXSample");
            _particles.Spawn("Jump");
            //Profiler.EndSample();
            Sounds.Play("Jump");
        }

        public void UpdateSpriteDirection(Vector2 direction) // Отвечает за поворот спрайта при движении
        {
            var multiplier = _invertScale ? -1 : 1;
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(multiplier, 1, 1);// Равно единичному вектору

            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1 * multiplier, 1, 1);
            }
        }
        public virtual void TakeDamage()
        {
            _isJumping = false;
            Animator.SetTrigger(Hit);
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, _damageVelocity);
            
        }

        public virtual void Attack()
        {
            Animator.SetTrigger(AttackKey);
            
        }

        public void OnDoAttack()
        {
            _attackRange.Check();
            _particles.Spawn("Slash");
            Sounds.Play("Melee");

        }
    }
}



