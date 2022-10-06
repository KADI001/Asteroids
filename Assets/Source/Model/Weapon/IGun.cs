using System;
using Source.Model.Pause;
using Source.Model.Ship;
using Source.Model.Utils;
using UnityEngine;

namespace Source.Model.Weapon
{
    public interface IGun
    {
        public event Action<Bullet> Shot;

        public bool TryShoot(Vector2 point, Vector2 direction);
        public Bullet GetBullet(Vector2 at, Vector2 direction);
        public bool CanShoot();
    }
}