namespace UniTemplate.Scripts.UI
{
    using GameDevelopmentKit.GameFoundationCore.AssetsManager;
    using GameDevelopmentKit.GameFoundationCore.Scene;
    using GameDevelopmentKit.GameFoundationCore.Scripts.ScreenFlow.Base.Presenter;
    using ILogServices = GameFoundationCore.LogServices.ILogServices;
    using SignalTransmitter = GameFoundationCore.Signals.SignalTransmitter;

    public class LoadingScreenView : TemplateLoadingScreenView
    {

    }

    [ScreenInfo(nameof(LoadingScreenView))]
    public class LoadingScreenPresenter : TemplateLoadingScreenPresenter
    {
        protected LoadingScreenPresenter(
            SignalTransmitter signalTransmitter,
            ILogServices logServices,
            IGameAssets gameAssets
            ) : base(signalTransmitter, logServices, gameAssets) { }
    }
}