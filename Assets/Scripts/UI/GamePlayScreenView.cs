namespace GameFoundationCore.HyperCasual.UI
{
    using GameDevelopmentKit.GameFoundationCore.Scripts.ScreenFlow.Base.Presenter;
    using GameDevelopmentKit.GameFoundationCore.Scripts.ScreenFlow.Base.View;
    using GameFoundationCore.LogServices;
    using GameFoundationCore.Signals;
    using UnityEngine;
    using UnityEngine.UI;

    public class GamePlayScreenView : BaseView
    {
        [field: SerializeField] public Image BackgroundImage { get; set; }
    }

    [ScreenInfo(nameof(GamePlayScreenView))]
    public class GamePlayScreenPresenter : BaseScreenPresenter<GamePlayScreenView>
    {
        protected GamePlayScreenPresenter(
            SignalTransmitter signalTransmitter, 
            ILogServices logServices
            ) : base(signalTransmitter, logServices)
        {
        }

        private void SetBackGround()
        {
            this.View.BackgroundImage.color = Color.black;
        }
    }
}