using Assets.Source.Model;
using Assets.Source.Model.Enemy;
using Assets.Source.Model.Factory;
using Assets.Source.Model.Pause;
using Assets.Source.Model.Score;
using Assets.Source.Model.Ship;
using Assets.Source.Model.Weapon;
using Assets.Source.Presenters;
using Assets.Source.Presenters.Factory;

namespace Assets.Source.StateMachines
{
    public class GameInitializingState : IState
    {
        public const string Initial = "Initial";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public GameInitializingState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() => 
            _sceneLoader.Load(Initial, EnterLoadGame);

        public void Exit()
        {
            
        }

        private void EnterLoadGame()
        {
            DIContainer.Container.RegisterSingle<IPresenterProvider>(new PresenterProvider());
            DIContainer.Container.RegisterSingle<IPresenterFactory>(new PresenterFactory(DIContainer.Container.GetSingle<IPresenterProvider>()));
            DIContainer.Container.RegisterSingle<IEnemyPresenterFactory>(DIContainer.Container.GetSingle<IPresenterFactory>());
            DIContainer.Container.RegisterSingle<IShipInput>(new ShipShipInput());
            DIContainer.Container.RegisterSingle<IGameFactory>(new GameFactory());
            DIContainer.Container.RegisterSingle<IBulletFactory>(DIContainer.Container.GetSingle<IGameFactory>());
            DIContainer.Container.RegisterSingle<IPauseManger>(new PauseManger());
            DIContainer.Container.RegisterSingle<IPauseRegister>(DIContainer.Container.GetSingle<IPauseManger>());
            DIContainer.Container.RegisterSingle<IPauseUnRegister>(DIContainer.Container.GetSingle<IPauseManger>());
            DIContainer.Container.RegisterSingle<IEnemiesContainer>(new EnemiesContainer());

            _gameStateMachine.Enter<LoadGameState>();
        }
    }
}