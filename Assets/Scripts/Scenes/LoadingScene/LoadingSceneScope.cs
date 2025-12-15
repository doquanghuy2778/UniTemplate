namespace Bow.Scripts.Scenes.LoadingScene
{
    using GameFoundationCore.DI;
    using GameFoundationCore.Scripts.Extension;
    using UniTemplate.Scripts.UI;
    using UnityEngine;
    using VContainer;

    public class LoadingSceneScope : SceneScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("LoadingSceneScope Configure");
            builder.InitScreenManually<LoadingScreenPresenter>();
        }
    }
}