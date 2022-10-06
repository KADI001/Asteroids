using System;
using Source.Model;
using Source.Model.Enemy;
using Source.Model.Score;
using Source.Model.Ship;
using Source.Model.Weapon;
using Source.Presenters.Bullet;
using Source.Presenters.Enemy;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Source.Presenters.Factory
{
    public sealed class PresenterFactory : IPresenterFactory
    {
        private readonly IPresenterProvider _presenterProvider;

        public PresenterFactory(IPresenterProvider presenterProvider) => 
            _presenterProvider = presenterProvider;

        public ShipPresenter CreateShip(Ship ship, Camera camera) => 
            CreateObject<ShipPresenter>(_presenterProvider.GetShip(), ship, camera);

        public LaserBulletPresenter CreateLaserBullet(LaserBullet bullet, Camera camera) => 
            CreateObject<LaserBulletPresenter>(_presenterProvider.GetLaserBullet(), bullet, camera);

        public DefaultBulletPresenter CreateDefaultBullet(DefaultBullet bullet, Camera camera) => 
            CreateObject<DefaultBulletPresenter>(_presenterProvider.GetDefaultBullet(), bullet, camera);

        public AsteroidPresenter CreateAsteroid(Asteroid asteroid, Camera camera) => 
            CreateObject<AsteroidPresenter>(_presenterProvider.GetAsteroid(), asteroid, camera);

        public AsteroidPartPresenter CreateAsteroidPart(AsteroidPart asteroidPart, Camera camera) =>
            CreateObject<AsteroidPartPresenter>(_presenterProvider.GetAsteroidPart(), asteroidPart, camera);

        public AsteroidPartPresenter[] CreateAsteroidParts(AsteroidPart[] asteroidParts, Camera camera)
        {
            AsteroidPartPresenter[] asteroidPartPresenters = new AsteroidPartPresenter[asteroidParts.Length];

            for (int i = 0; i < asteroidParts.Length; i++)
            {
                asteroidPartPresenters[i] = CreateAsteroidPart(asteroidParts[i], camera);
            }

            return asteroidPartPresenters;
        }

        public UfoPresenter CreateUfo(Ufo ufo, Camera camera) => 
            CreateObject<UfoPresenter>(_presenterProvider.GetUfo(), ufo,camera);

        public Hud CreateHud(ShipMovement shipMovement, LaserGun laserGun, Score score)
        {
            Hud hud = Object.Instantiate(_presenterProvider.GetHud());
            hud.Init(shipMovement, laserGun, score);
            return hud;
        }

        public GameEndWindowPresenter CreateGameEndWindow(IShipInput shipInput, Action onRestarted)
        {
            GameEndWindowPresenter gameEndWindowPresenter = Object.Instantiate(_presenterProvider.GetGameEndWindow());
            gameEndWindowPresenter.Init(shipInput, onRestarted);
            return gameEndWindowPresenter;
        }

        private static T CreateObject<T>(Presenter template, Transformable model, Camera camera) where T : notnull, Presenter
        {
            Presenter presenter = UnityEngine.Object.Instantiate(template);
            presenter.Init(model, camera);

            return (T)presenter;
        }
    }
}