using Assets.Source.Model.Factory;
using Assets.Source.Model.Ship;
using Assets.Source.Model.Weapon;
using Assets.Source.Presenters.Bullet;

namespace Assets.Source.Presenters.Factory
{
    public interface IPresenterFactory : IEnemyPresenterFactory
    {
        ShipPresenter CreateShip(Ship ship);
        LaserBulletPresenter CreateLaserBullet(LaserBullet bullet);
        DefaultBulletPresenter CreateDefaultBullet(DefaultBullet bullet);
    }
}