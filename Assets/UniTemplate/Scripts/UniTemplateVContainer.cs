namespace UniTemplate.Scripts
{
    using UniTemplate.AssetsManager;
    using UniTemplate.DI;
    using UniTemplate.ScreenFlow.Manager;
    using VContainer;

    public static class UniTemplateVContainer
    {
        public static void RegisterUniTemplateVContainer(this IContainerBuilder builder)
        {
            builder.Register<VcontainerWrapper>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<GameAssets>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<ScreenManager>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}