using System;
using System.Collections.Generic;

namespace Source.StateMachine
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(GameInitializingState)] = new GameInitializingState(this, sceneLoader, DIContainer.Container),
                [typeof(LoadGameState)] = new LoadGameState(this, sceneLoader, DIContainer.Container),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            IState state = GetStateByType<TState>();
            _activeState = state;
            state.Enter();
        }

        public void Enter<TState, TPayload1>(TPayload1 payLoad1) where TState : class, IPayloadState<TPayload1>
        {
            _activeState?.Exit();
            IPayloadState<TPayload1> payloadState = GetStateByType<TState>();
            _activeState = payloadState;
            payloadState.Enter(payLoad1);
        }

        public void Enter<TState, TPayload1, TPayload2, TPayload3>(TPayload1 payLoad1, TPayload2 payload2, TPayload3 payload3) where TState : class, IPayloadState<TPayload1, TPayload2, TPayload3>
        {
            _activeState?.Exit();
            IPayloadState<TPayload1, TPayload2, TPayload3> payloadState = GetStateByType<TState>();
            _activeState = payloadState;
            payloadState.Enter(payLoad1, payload2, payload3);
        }

        public void Enter<TState, TPayload1, TPayload2, TPayload3, TPayload4>(TPayload1 payLoad1, TPayload2 payload2, TPayload3 payload3, TPayload4 payload4) where TState : class, IPayloadState<TPayload1, TPayload2, TPayload3, TPayload4>
        {
            _activeState?.Exit();
            IPayloadState<TPayload1, TPayload2, TPayload3, TPayload4> payloadState = GetStateByType<TState>();
            _activeState = payloadState;
            payloadState.Enter(payLoad1, payload2, payload3, payload4);
        }

        private TState GetStateByType<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}