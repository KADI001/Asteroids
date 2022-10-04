using Assets.Source.StateMachines;
using UnityEngine;

namespace Assets.Source
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.GameStateMachine.Enter<GameInitializingState>();

            DontDestroyOnLoad(this);
        }
    }
}
