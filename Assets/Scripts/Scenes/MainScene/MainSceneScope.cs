namespace Bow.Scripts.Scenes.MainScene
{
    using System.Linq;
    using GameDevelopmentKit.GameFoundationCore.StateMachine.Interface;
    using GameFoundationCore.DI;
    using GameFoundationCore.HyperCasual.StateMachine;
    using GameFoundationCore.HyperCasual.StateMachine.Interface;
    using GameFoundationCore.Scripts.Extension;
    using VContainer;

    public class MainSceneScope : SceneScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Singleton)
                .WithParameter(container => typeof(IGameState).GetDerivedTypes().Select(type => (IState)container.Instantiate(type)).ToList())
                .AsInterfacesAndSelf();
        }
    }
}