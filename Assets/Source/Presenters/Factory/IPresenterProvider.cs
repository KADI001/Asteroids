using Source.Presenters.Bullet;
using Source.Presenters.Enemy;
using UnityEngine;

namespace Source.Presenters.Factory
{
    public interface IPresenterProvider
    {
        public ShipPresenter GetShip();
        public AsteroidPresenter GetAsteroid();
        public AsteroidPartPresenter GetAsteroidPart();
        public UfoPresenter GetUfo();
        public LaserBulletPresenter GetLaserBullet();
        public DefaultBulletPresenter GetDefaultBullet();
        public Hud GetHud();
        public GameEndWindowPresenter GetGameEndWindow();
    }
}