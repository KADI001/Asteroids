using Source.Model.Weapon;
using UnityEngine;

namespace Source.Presenters.Factory
{
    public class BulletFactory
    {
        private Camera _camera;
        private readonly IPresenterFactory _presenterFactory;
        private readonly IGun _firstGun;
        private readonly IGun _secondGun;

        public BulletFactory(Camera camera, IPresenterFactory presenterFactory, IGun firstGun, IGun secondGun)
        {
            _camera = camera;
            _presenterFactory = presenterFactory;
            _firstGun = firstGun;
            _secondGun = secondGun;

            OnEnable();
        }

        private void OnEnable()
        {
            _firstGun.Shot += OnFirstGunShot;
            _secondGun.Shot += OnSecondGunShot;
        }

        private void OnDisable()
        {
            _firstGun.Shot -= OnFirstGunShot;
            _secondGun.Shot -= OnSecondGunShot;
        }

        private void OnSecondGunShot(Model.Weapon.Bullet bullet)
        {
            CreateBullet(bullet);
        }

        private void OnFirstGunShot(Model.Weapon.Bullet bullet)
        {
            CreateBullet(bullet);
        }

        private void CreateBullet(Model.Weapon.Bullet bullet)
        {
            if (bullet is LaserBullet laserBullet)
                _presenterFactory.CreateLaserBullet(laserBullet, _camera);
            else
                _presenterFactory.CreateDefaultBullet((DefaultBullet)bullet, _camera);
        }
    }
}
