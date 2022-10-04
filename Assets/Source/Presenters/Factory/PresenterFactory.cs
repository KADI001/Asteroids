using Assets.Source.Model;
using Assets.Source.Model.Enemy;
using Assets.Source.Model.Ship;
using Assets.Source.Model.Utils;
using Assets.Source.Model.Weapon;
using Assets.Source.Presenters.Bullet;
using Assets.Source.Presenters.Enemy;
using Object = UnityEngine.Object;

namespace Assets.Source.Presenters.Factory
{
    public sealed class PresenterFactory : IPresenterFactory
    {
        private readonly IPresenterProvider _presenterProvider;

        public PresenterFactory(IPresenterProvider presenterProvider)
        {
            _presenterProvider = presenterProvider;
        }

        public ShipPresenter CreateShip(Ship ship) => 
            CreateObject<ShipPresenter>(_presenterProvider.GetShip(), ship);

        public LaserBulletPresenter CreateLaserBullet(LaserBullet bullet) => 
            CreateObject<LaserBulletPresenter>(_presenterProvider.GetLaserBullet(), bullet);

        public DefaultBulletPresenter CreateDefaultBullet(DefaultBullet bullet) => 
            CreateObject<DefaultBulletPresenter>(_presenterProvider.GetDefaultBullet(), bullet);

        public AsteroidPresenter CreateAsteroid(Asteroid asteroid) => 
            CreateObject<AsteroidPresenter>(_presenterProvider.GetAsteroid(), asteroid);

        public AsteroidPartPresenter CreateAsteroidPart(AsteroidPart asteroidPart) =>
            CreateObject<AsteroidPartPresenter>(_presenterProvider.GetAsteroidPart(), asteroidPart);

        public AsteroidPartPresenter[] CreateAsteroidParts(AsteroidPart[] asteroidParts)
        {
            AsteroidPartPresenter[] asteroidPartPresenters = new AsteroidPartPresenter[asteroidParts.Length];

            for (int i = 0; i < asteroidParts.Length; i++)
            {
                asteroidPartPresenters[i] = CreateAsteroidPart(asteroidParts[i]);
            }

            return asteroidPartPresenters;
        }

        public UfoPresenter CreateUfo(Ufo ufo) => 
            CreateObject<UfoPresenter>(_presenterProvider.GetUfo(), ufo);

        private static T CreateObject<T>(Presenter template, Transformable model) where T : notnull, Presenter
        {
            Presenter presenter = Object.Instantiate(template);
            presenter.Init(model);

            return (T)presenter;
        }
    }
}