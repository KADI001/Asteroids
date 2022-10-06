using System;
using Source.Model.Factory;
using Source.Model.Utils;
using UnityEngine;

namespace Source.Model.Weapon
{
    public class DefaultGun : IGun
    {
        private readonly IBulletFactory _bulletFactory;
        public readonly Timer Timer;

        public event Action<Bullet> Shot;

        public DefaultGun(IBulletFactory bulletFactory, float reloadingInSeconds)
        {
            _bulletFactory = bulletFactory;
            Timer = new Timer(reloadingInSeconds);
        }

        public bool TryShoot(Vector2 point, Vector2 direction)
        {
            if (CanShoot() == false)
                return false;

            Shot?.Invoke(GetBullet(point, direction));
            return true;
        }

        public Bullet GetBullet(Vector2 at, Vector2 direction) => 
            _bulletFactory.GetDefaultBullet(at, direction);

        public bool CanShoot() => 
            Timer.IsRunning == false;
    }
}