using Source.Model.Ship;
using Source.Presenters;

namespace Source.StateMachine
{
    public class GameLoopState : IPayloadState<IEnemySpawner>
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(IEnemySpawner enemySpawner)
        {
            enemySpawner.Start();
        }

        public void Exit()
        {
            
        }
    }
}