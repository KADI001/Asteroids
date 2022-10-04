namespace Assets.Source.StateMachines
{
    public class LoadGameState : IState
    {
        public const string LevelName = "Level";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadGameState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() => 
            _sceneLoader.Load(LevelName, OnSceneLoaded);

        public void Exit()
        {
        }

        private void OnSceneLoaded() => 
            _gameStateMachine.Enter<GameLoopState>();
    }
}