namespace Bow.Scripts.Scenes.LoadingScene
{
    using GameDevelopmentKit.GameFoundationCore.Scene;
    using GameFoundationCore.DI;
    using GameFoundationCore.Scripts.Extension;
    using UnityEngine;
    using VContainer;

    public class LoadingSceneScope : SceneScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("LoadingSceneScope Configure");
            builder.InitScreenManually<TemplateLoadingScreenPresenter>();
        }
    }
}