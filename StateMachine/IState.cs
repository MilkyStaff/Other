namespace StateMachine
{
    public interface IState { }

    interface IEnterableState : IState
    {
        void Enter();
    }
    interface IExitableState : IState
    {
        void Exit();
    }
    interface IUpdatableState : IState
    {
        void Update();
    }
}