namespace GameFoundationCore.HyperCasual.StateMachine
{
    using System.Collections.Generic;
    using GameDevelopmentKit.GameFoundationCore.StateMachine.Controller;
    using GameDevelopmentKit.GameFoundationCore.StateMachine.Interface;
    using GameFoundationCore.DI;
    using GameFoundationCore.HyperCasual.StateMachine.State;
    using ILogServices = GameFoundationCore.LogServices.ILogServices;

    public class GameStateMachine : StateMachine, IInitializable
    {
        protected GameStateMachine(
            List<IState> states,
            ILogServices logServices
        ) : base(states, logServices)
        {

        }

        public void Initialize()
        {
            this.TransitionTo<GameHomeState>();
        }
    }
}