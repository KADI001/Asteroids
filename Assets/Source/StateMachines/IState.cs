namespace Source.StateMachine
{
    public interface IState : IExitableState
    {
        public void Enter();
    }

    public interface IExitableState
    {
        public void Exit();
    }

    public interface IPayloadState<T1> : IExitableState
    {
        public void Enter(T1 param1);
    }

    public interface IPayloadState<T1, T2> : IExitableState
    {
        public void Enter(T1 param1, T2 param2);
    }

    public interface IPayloadState<T1, T2, T3> : IExitableState
    {
        public void Enter(T1 param1, T2 param2, T3 param3);
    }
    public interface IPayloadState<T1, T2, T3, T4> : IExitableState
    {
        public void Enter(T1 param1, T2 param2, T3 param3, T4 param4);
    }
}