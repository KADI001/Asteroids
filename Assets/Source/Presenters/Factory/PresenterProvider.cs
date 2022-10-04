using Assets.Source.Presenters.Bullet;
using Assets.Source.Presenters.Enemy;
using UnityEngine;

namespace Assets.Source.Presenters.Factory
{
    public sealed class PresenterProvider : IPresenterProvider
    {
        public const string ShipPresenter = "Prefabs/Ship";
        public const string LaserBulletPresenter = "Prefabs/LaserBullet";
        public const string DefaultBulletPresenter = "Prefabs/DefaultBullet";
        public const string AsteroidPresenter = "Prefabs/Asteroid";
        public const string AsteroidPartPresenter = "Prefabs/AsteroidPart";
        public const string UfoPresenter = "Prefabs/Ufo";

        public ShipPresenter GetShip() => GetPrefab<ShipPresenter>(ShipPresenter);
        public AsteroidPresenter GetAsteroid() => GetPrefab<AsteroidPresenter>(AsteroidPresenter);
        public UfoPresenter GetUfo() => GetPrefab<UfoPresenter>(UfoPresenter);
        public LaserBulletPresenter GetLaserBullet() => GetPrefab<LaserBulletPresenter>(LaserBulletPresenter);
        public DefaultBulletPresenter GetDefaultBullet() => GetPrefab<DefaultBulletPresenter>(DefaultBulletPresenter);
        public AsteroidPartPresenter GetAsteroidPart() => GetPrefab<AsteroidPartPresenter>(AsteroidPartPresenter);

        private static TPresenter GetPrefab<TPresenter>(string path) where TPresenter : Presenter => Resources.Load<TPresenter>(path);
    }
}