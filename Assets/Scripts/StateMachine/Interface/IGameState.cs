namespace GameFoundationCore.HyperCasual.StateMachine.Interface
{
    using GameDevelopmentKit.GameFoundationCore.StateMachine.Interface;

    public interface IGameState : IState
    {

    }

    public interface IGameState<T> : IGameState
    {
        T Model { get; set; }
    }
}