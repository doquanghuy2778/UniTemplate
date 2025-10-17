namespace UniTemplate.Scripts
{
    using UniTemplate.AssetsManager;
    using UniTemplate.ScreenFlow.Manager;
    using VContainer;

    public static class UniTemplateVContainer
    {
        public static void RegisterUniTemplateVContainer(this IContainerBuilder builder)
        {
            builder.Register<GameAssets>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ScreenManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}