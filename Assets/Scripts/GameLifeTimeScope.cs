namespace UniTemplate.HyperCasual
{
    using AssetsManager.AssetsManager.Runtime;
    using UniTemplate.ScreenFlow.Manager;
    using VContainer;
    using VContainer.Unity;

    public class GameLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameAssets>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ScreenManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}