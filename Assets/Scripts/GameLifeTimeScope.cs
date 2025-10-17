namespace UniTemplate.HyperCasual
{
    using UniTemplate.AssetsManager;
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