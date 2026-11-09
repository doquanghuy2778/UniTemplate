using GameFoundationCore.ScreenFlow.Manager;

namespace GameFoundationCore.HyperCasual.StateMachine.State
{
    using GameFoundationCore.HyperCasual.StateMachine.Interface;

    public class GameHomeState : IGameState
    {
        private readonly IScreenManager screenManager;

        public GameHomeState(
            IScreenManager screenManager
            )
        {
            this.screenManager = screenManager;
        }
        
        public void Enter()
        {
        }

        public void Exit()
        {

        }
    }
}