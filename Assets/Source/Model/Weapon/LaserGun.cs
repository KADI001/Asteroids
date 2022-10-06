using System;
using Source.Model.Factory;
using Source.Model.Utils;
using UnityEngine;

namespace Source.Model.Weapon
{
    public class LaserGun : IGun, IUpdatable
    {
        public const int MaxCharges = 10;

        public readonly Timer Timer;

        private readonly IBulletFactory _bulletFactory;
        private int _charges;

        public event Action<Bullet> Shot;

        public LaserGun(IBulletFactory bulletFactory, float chargeRecoveryInSeconds)
        {
            _bulletFactory = bulletFactory;
            Timer = new Timer(chargeRecoveryInSeconds);
            _charges = MaxCharges;

            Timer.Start(OnTimerFinished);
        }

        public int Charges => _charges;

        public bool TryShoot(Vector2 point, Vector2 direction)
        {
            if (CanShoot() == false) 
                return false;

            Shot?.Invoke(GetBullet(point, direction));
            _charges--;
            return true;
        }

        public void Update(float deltaTime)
        {
            if (_charges >= MaxCharges)
            {
                Timer.Reset();
                return;
            }

            if (Timer.IsRunning == false) 
                Timer.Restart();

            Timer.Update(deltaTime);
        }

        public bool CanShoot() => 
            _charges > 0;

        public Bullet GetBullet(Vector2 at, Vector2 direction) => 
            _bulletFactory.GetLaserBullet(at, direction);

        public void ResetCharges() =>
            _charges = MaxCharges;

        private void OnTimerFinished() => 
            _charges++;
    }
}