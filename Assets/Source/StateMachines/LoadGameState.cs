using Source.Model.Enemy;
using Source.Model.Factory;
using Source.Model.Pause;
using Source.Model.Score;
using Source.Model.Ship;
using Source.Model.Weapon;
using Source.Presenters;
using Source.Presenters.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.StateMachine
{
    public class LoadGameState : IState
    {
        public const string LevelName = "Level";
        public const float ReloadingInSeconds = 0.2f;
        public const float ChargeRecoveryInSeconds = 3f;

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly DIContainer _diContainer;

        private IServiceFactory _serviceFactory;
        private IPresenterFactory _presenterFactory;
        private IGameFactory _gameFactory;
        private IEnemiesContainer _enemiesContainer;
        private IShipInput _shipInput;
        private IPauseManger _pauseManager;
        private Camera _camera;
        private ModelUpdater _modelUpdater;
        private GameEndWindowPresenter _gameEndWindowPresenter;
        private Ship _ship;
        private ShipController _shipController;
        private LaserGun _laserGun;
        private ScoreCounter _scoreCounter;
        private Score _score;

        public LoadGameState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, DIContainer diContainer)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _diContainer = diContainer;
        }

        public void Enter() => 
            _sceneLoader.Load(LevelName, OnSceneLoaded);


        public void Exit()
        {
        }

        private void OnSceneLoaded()
        {
            _serviceFactory = _diContainer.GetSingle<IServiceFactory>();
            _presenterFactory = _diContainer.GetSingle<IPresenterFactory>();
            _gameFactory = _diContainer.GetSingle<IGameFactory>();
            _pauseManager = _diContainer.GetSingle<IPauseManger>();
            _enemiesContainer = _diContainer.GetSingle<IEnemiesContainer>();
            _shipInput = _diContainer.GetSingle<IShipInput>();
            _camera = Camera.main;

            _ship = new Ship(Vector2.zero, 0);

            Vector2 leftTopBound = _camera.ViewportToWorldPointFromCamera(Vector2.up);
            Vector2 rightDownBound = _camera.ViewportToWorldPointFromCamera(Vector2.right);

            ShipMovement shipMovement = new ShipMovement(_ship, leftTopBound, rightDownBound);

            ShipPresenter shipPresenter = _presenterFactory.CreateShip(_ship, _camera);
            _shipController = shipPresenter.Controller;
            _shipController.Init(_shipInput, shipMovement, _camera);

            DefaultGun defaultGun = new DefaultGun(_gameFactory, ReloadingInSeconds);
            _laserGun = new LaserGun(_gameFactory, ChargeRecoveryInSeconds);

            BulletFactory bulletFactory = new BulletFactory(_camera, _presenterFactory, defaultGun, _laserGun);

            _shipController.
                BindFirstGun(defaultGun).
                BindSecondGun(_laserGun);

            EnemySpawner enemySpawner = new EnemySpawner(_camera, _ship, _presenterFactory, _pauseManager, _enemiesContainer);
            _modelUpdater = _serviceFactory.CreateModelUpdater();

            _pauseManager.Register(shipMovement);
            _pauseManager.Register(enemySpawner);
            _pauseManager.Register(_modelUpdater);

            _modelUpdater.Register(_laserGun);
            _modelUpdater.Register(shipMovement);
            _modelUpdater.Register(enemySpawner);

            _modelUpdater.Enable();

            _score = new Score();
            _scoreCounter = new ScoreCounter(_score, _enemiesContainer);
            Hud hud = _presenterFactory.CreateHud(shipMovement, _laserGun, _score);
            _gameEndWindowPresenter = _presenterFactory.CreateGameEndWindow(_shipInput, OnGameRestarted);

            _shipInput.Disabled += OnShipInputDisabled;

            _gameStateMachine.Enter<GameLoopState, IEnemySpawner>(enemySpawner);
        }

        private void OnShipInputDisabled()
        {
            _modelUpdater.Disable();
            _gameEndWindowPresenter.Show();
        }

        private void OnGameRestarted()
        {
            _gameEndWindowPresenter.Hide();
            _ship.MoveTo(Vector2.zero);
            _ship.SetRotation(0f);
            _shipController.ResetMovementState();
            _shipController.EnableShipControl();
            _laserGun.ResetCharges();
            _enemiesContainer.DestroyAll();
            _pauseManager.ResumeAll();
            _score.Reset();
        }
    }
}