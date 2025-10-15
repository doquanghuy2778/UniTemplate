namespace UniTemplate.ScreenFlow.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AssetsManager.AssetsManager.Runtime;
    using Cysharp.Threading.Tasks;
    using UniTemplate.ScreenFlow.Base;
    using VContainer.Unity;

    public interface IScreenManager
    {
        public UniTask<TPresenter> OpenScreen<TPresenter>() where TPresenter : IScreenLifecycle;
        public UniTask<TPresenter> OpenScreen<TPresenter, TModel>(TModel model) where TPresenter : IScreenLifecycle<TModel>;

        /// <summary>
        /// Close current screen on top
        /// </summary>
        /// <returns></returns>
        public UniTask CloseCurrentScreen();

        /// <summary>
        /// Close all screen in queue async
        /// </summary>
        /// <returns></returns>
        public UniTask CloseAllScreenAsync();

        /// <summary>
        /// Close all screen in queue
        /// </summary>
        public void CloseAllScreen();

    }

    public class ScreenManager : IScreenManager, ITickable, IInitializable, IDisposable
    {
        #region Constructor

        private readonly IGameAssets gameAssets;

        private ScreenManager(IGameAssets gameAssets)
        {
            this.gameAssets = gameAssets;
        }

        #endregion

        private readonly List<IScreenLifecycle>                   activeScreens       = new();
        private readonly Dictionary<Type, IScreenLifecycle>       typeToLoadScreen    = new();
        private readonly Dictionary<Type, Task<IScreenLifecycle>> typeToPendingScreen = new();

        // public async UniTask<T> GetScreen<T>() where T : IScreenLifecycle
        // {
        //     var screenType = typeof(T);
        //
        //     if (this.typeToLoadedScreenPresenter.TryGetValue (screenType, out var screenPresenter)) return (T)screenPresenter;
        //
        //     if (!this.typeToPendingScreen.TryGetValue(screenType, out var loadingTask))
        //     {
        //         loadingTask = InstantiateScreen();
        //         this.typeToPendingScreen.Add(screenType, loadingTask);
        //     }
        //
        //     var result = await loadingTask;
        //     this.typeToPendingScreen.Remove(screenType);
        //
        //     return (T)result;
        //
        //     async Task<IScreenLifecycle> InstantiateScreen()
        //     {
        //         screenPresenter = this.GetCurrentContainer().Instantiate<T>();
        //         var screenInfo = screenPresenter.GetCustomAttribute<ScreenInfoAttribute>();
        //
        //         var viewObject = Object.Instantiate(await this.gameAssets.LoadAssetAsync<GameObject>(screenInfo.AddressableScreenPath),
        //             this.CheckPopupIsOverlay(screenPresenter) ? this.CurrentOverlayRoot : this.CurrentRootScreen).GetComponent<IScreenView>();
        //
        //         screenPresenter.SetView(viewObject);
        //         this.typeToLoadedScreenPresenter.Add(screenType, screenPresenter);
        //
        //         return (T)screenPresenter;
        //     }
        // }

        public UniTask<TPresenter> OpenScreen<TPresenter>() where TPresenter : IScreenLifecycle
        {
            throw new System.NotImplementedException();
        }

        public UniTask<TPresenter> OpenScreen<TPresenter, TModel>(TModel model) where TPresenter : IScreenLifecycle<TModel>
        {
            throw new System.NotImplementedException();
        }

        public UniTask CloseCurrentScreen()
        {
            throw new System.NotImplementedException();
        }

        public UniTask CloseAllScreenAsync()
        {
            throw new System.NotImplementedException();
        }

        public void CloseAllScreen()
        {
            throw new System.NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}