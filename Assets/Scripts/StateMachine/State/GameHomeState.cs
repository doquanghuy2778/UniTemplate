using GameFoundationCore.ScreenFlow.Manager;
using UI;

namespace GameFoundationCore.HyperCasual.StateMachine.State
{
    using GameFoundationCore.HyperCasual.StateMachine.Interface;

    public class GameHomeState : IGameState
    {
        private readonly IScreenManager _screenManager;

        public GameHomeState(
            IScreenManager screenManager
            )
        {
            _screenManager = screenManager;
        }
        
        public void Enter()
        {
            this._screenManager.OpenScreen<TestUIScreenPresenter>();
        }

        public void Exit()
        {

        }
    }
}