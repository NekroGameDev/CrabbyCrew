using Assets.PixelCrew.Scripts.Creatures.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Creatures.Weapon
{
    public class Projectile : BaseProjectile
    {

        protected override void  Start()
        {
            base.Start();

            var force = new Vector2(Direction * _speed, 0);
            Rigidbody.AddForce(force, ForceMode2D.Impulse);
        }

       
    }
}

