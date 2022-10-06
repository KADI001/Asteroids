using Source.StateMachine;

namespace Source
{
    public class Game
    {
        public GameStateMachine GameStateMachine { get; }

        public Game(ICoroutineRunner coroutineRunner) => 
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
    }
}