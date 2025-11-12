namespace GameFoundationCore.HyperCasual
{
    using GameFoundationCore.Scripts;
    using VContainer;
    using VContainer.Unity;

    public class GameLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterGameFoundationCoreVContainer();
        }
    }
}