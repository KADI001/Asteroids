using System;
using Source.Model.Score;
using Source.Model.Ship;
using Source.Model.Weapon;
using Source.Presenters.Bullet;
using UnityEngine;

namespace Source.Presenters.Factory
{
    public interface IPresenterFactory : IEnemyPresenterFactory
    { 
        ShipPresenter CreateShip(Ship ship, Camera camera);
        LaserBulletPresenter CreateLaserBullet(LaserBullet bullet, Camera camera);
        DefaultBulletPresenter CreateDefaultBullet(DefaultBullet bullet, Camera camera);
        Hud CreateHud(ShipMovement shipMovement, LaserGun laserGun, Score score);
        GameEndWindowPresenter CreateGameEndWindow(IShipInput shipInput, Action onRestarted);
    }
}