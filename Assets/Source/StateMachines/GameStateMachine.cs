using System;
using System.Collections.Generic;

namespace Assets.Source.StateMachines
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(GameInitializingState)] = new GameInitializingState(this, sceneLoader),
                [typeof(LoadGameState)] = new LoadGameState(this, sceneLoader),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            _activeState = GetStateByType<TState>();
            _activeState.Enter();
        }

        private IState GetStateByType<TState>() where TState : IState => 
            _states[typeof(TState)];
    }
}