using Source.Model;
using Source.Model.Enemy;
using Source.Model.Factory;
using Source.Model.Pause;
using Source.Model.Score;
using Source.Model.Ship;
using Source.Model.Weapon;
using Source.Presenters;
using Source.Presenters.Factory;

namespace Source.StateMachine
{
    public class GameInitializingState : IState
    {
        public const string Initial = "Initial";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly DIContainer DiContainer;

        public GameInitializingState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, DIContainer diContainer)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            DiContainer = diContainer;
        }

        public void Enter() => 
            _sceneLoader.Load(Initial, EnterLoadGame);

        public void Exit()
        {
            
        }

        private void EnterLoadGame()
        {
            DiContainer.RegisterSingle<IPresenterProvider>(new PresenterProvider());
            DiContainer.RegisterSingle<IPresenterFactory>(new PresenterFactory(DiContainer.GetSingle<IPresenterProvider>()));
            DiContainer.RegisterSingle<IEnemyPresenterFactory>(DiContainer.GetSingle<IPresenterFactory>());
            DiContainer.RegisterSingle<IShipInput>(new ShipInput());
            DiContainer.RegisterSingle<IGameFactory>(new GameFactory());
            DiContainer.RegisterSingle<IBulletFactory>(DiContainer.GetSingle<IGameFactory>());
            DiContainer.RegisterSingle<IServiceProvider>(new ServiceProvider());
            DiContainer.RegisterSingle<IServiceFactory>(new ServiceFactory(DiContainer.GetSingle<IServiceProvider>()));
            DiContainer.RegisterSingle<IPauseManger>(new PauseManger());
            DiContainer.RegisterSingle<IPauseRegister>(DiContainer.GetSingle<IPauseManger>());
            DiContainer.RegisterSingle<IPauseUnRegister>(DiContainer.GetSingle<IPauseManger>());
            DiContainer.RegisterSingle<IEnemiesContainer>(new EnemiesContainer());

            _gameStateMachine.Enter<LoadGameState>();
        }
    }
}