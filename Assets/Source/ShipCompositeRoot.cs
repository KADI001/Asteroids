using Assets.Source.Model;
using Assets.Source.Model.Enemy;
using Assets.Source.Model.Factory;
using Assets.Source.Model.Pause;
using Assets.Source.Model.Score;
using Assets.Source.Model.Ship;
using Assets.Source.Model.Weapon;
using Assets.Source.Presenters;
using Assets.Source.Presenters.Factory;
using UnityEngine;

namespace Assets.Source
{
    public class ShipCompositeRoot : MonoBehaviour
    {
        private const float ReloadingInSeconds = 0.2f;
        private const float ChargeRecoveryInSeconds = 3f;

        [SerializeField] private GameEndWindowPresenter _gameEndWindow;
        [SerializeField] private ScorePresenter _scorePresenter;
        [SerializeField] private DebugInfoPresenter _debugInfoPresenter;

        private Camera _camera;
        private IPresenterFactory _presenterFactory;
        private IGameFactory _gameFactory;
        private ScoreCounter _scoreCounter;

        private ShipMovement _shipMovement;
        private DefaultGun _defaultGun;
        private LaserGun _laserGun;
        private Ship _ship;

        private static DIContainer DiContainer => DIContainer.Container;
        private static IEnemiesContainer EnemiesContainer => DiContainer.GetSingle<IEnemiesContainer>();
        private static IPauseRegister PauseRegister => DiContainer.GetSingle<IPauseRegister>();
        private static IShipInput ShipInput => DiContainer.GetSingle<IShipInput>();
        public Ship Ship => _ship;

        private void Awake()
        {
            _presenterFactory = DiContainer.GetSingle<IPresenterFactory>();
            _gameFactory = DiContainer.GetSingle<IGameFactory>();
            _camera = Camera.main;

            Compose();
        }

        public void Compose()
        {
            _gameEndWindow.Hide();

            _ship = new Ship(Vector2.zero, 0);

            Vector2 leftTopBound = _camera.ViewportToWorldPoint(Vector2.up);
            Vector2 rightDownBound = _camera.ViewportToWorldPoint(Vector2.right);

            _shipMovement = new ShipMovement(Ship, leftTopBound, rightDownBound);

            ShipPresenter shipPresenter = _presenterFactory.CreateShip(Ship);
            shipPresenter.Controller.Init(_shipMovement);   

            _defaultGun = new DefaultGun(_gameFactory, ReloadingInSeconds);
            _laserGun = new LaserGun(_gameFactory, ChargeRecoveryInSeconds);

            shipPresenter.Controller.
                BindFirstGun(_defaultGun).
                BindSecondGun(_laserGun);

            _scoreCounter = new ScoreCounter(_scorePresenter.Model, EnemiesContainer);
            _debugInfoPresenter.Init(_shipMovement, _laserGun);

            PauseRegister.Register(_shipMovement);
        }

        private void Update() => 
            _laserGun.Update(Time.deltaTime);

        private void OnEnable()
        {
            _defaultGun.Shot += OnDefaultGunGunShot;
            _laserGun.Shot += OnLaserGunGunShot;
            ShipInput.Disabled += OnInputDisabled;
        }

        private void OnDisable()
        {
            _defaultGun.Shot -= OnDefaultGunGunShot;
            _laserGun.Shot -= OnLaserGunGunShot;
            ShipInput.Disabled -= OnInputDisabled;
        }

        private void OnInputDisabled() =>
            _gameEndWindow.Show();

        private void OnLaserGunGunShot(Bullet bullet) => 
            _presenterFactory.CreateLaserBullet((LaserBullet)bullet);

        private void OnDefaultGunGunShot(Bullet bullet) => 
            _presenterFactory.CreateDefaultBullet((DefaultBullet)bullet);
    }
}
