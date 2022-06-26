using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelCrew.Creatures
{


    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;


        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }
        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.Interact();
            }
        }
        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.Attack();
            }
        }

        public void OnThrow(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _hero.StartThrowing();
            }

            if (context.canceled)
            {
                _hero.UseInventory();
            }
        }

        public void OnNextItem(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.NextItem();
            }
        }
        
        public void OnUsePerk(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.UsePerk();
        }

        public void OnToggleFlasglight(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.ToggleFlashlight();
        }
    }
}