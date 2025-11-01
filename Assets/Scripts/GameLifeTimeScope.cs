namespace GameFoundationCore.HyperCasual
{
    using UniTemplate.Scripts;
    using VContainer;
    using VContainer.Unity;

    public class GameLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterUniTemplateVContainer();
        }
    }
}