using System;
using Assets.Source.Model.Pause;
using Assets.Source.Model.Ship;
using Assets.Source.Model.Utils;
using UnityEngine;

namespace Assets.Source.Model.Weapon
{
    public interface IGun
    {
        public event Action<Bullet> Shot;

        public bool TryShoot(Vector2 point, Vector2 direction);
        public Bullet GetBullet(Vector2 at, Vector2 direction);
        public bool CanShoot();
    }
}