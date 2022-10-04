using Assets.Source.Presenters.Bullet;
using Assets.Source.Presenters.Enemy;

namespace Assets.Source.Presenters.Factory
{
    public interface IPresenterProvider
    {
        public ShipPresenter GetShip();
        public AsteroidPresenter GetAsteroid();
        public AsteroidPartPresenter GetAsteroidPart();
        public UfoPresenter GetUfo();
        public LaserBulletPresenter GetLaserBullet();
        public DefaultBulletPresenter GetDefaultBullet();
    }
}