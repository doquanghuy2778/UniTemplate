namespace UniTemplate.AssetsManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.ResourceManagement.ResourceProviders;
    using UnityEngine.SceneManagement;
    using Object = System.Object;

    public interface IGameAssets
    {
        /// <summary>
        /// Preload assets
        /// </summary>
        /// <param name="targetScene"></param>
        /// <param name="keys"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<AsyncOperationHandle<T>> PreloadAsync<T>(string targetScene = "", params object[] keys);
        AsyncOperationHandle<List<AsyncOperationHandle<Object>>> LoadAssetsByLabelAsync(string label);
        
        
        /// <summary>
        /// load asset from addressable by key
        /// </summary>
        /// <param name="key">The key of location of the addressable</param>
        /// <param name="isAutoUnload">If true, asset will be automatically released when the current scene was unloaded</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        AsyncOperationHandle<T> LoadAssetAsync<T>(object key, bool isAutoUnload = true, string targetScene = "");
        
        /// <summary>
        /// load screen in addressable by key
        /// </summary>
        /// <param name="key">The key of location of the addressable</param>
        /// <param name="loadMode"></param>
        /// <param name="activeOnLoad"></param>
        /// <returns></returns>
        AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneMode loadMode = LoadSceneMode.Single, bool activeOnLoad = true);
    }
    
    public class GameAssets : IGameAssets
    {
        /// <summary>
        /// A dictionary use for manage the loading assets to make sure a asset doesn't call Addressable too many times at a time
        /// </summary>
        private readonly Dictionary<object, AsyncOperationHandle> loadingAssets = new(20);
        
        /// <summary>
        /// A dictionary use for caching the loaded assets
        /// </summary>
        private readonly Dictionary<object, AsyncOperationHandle> loadedAssets = new(100);
        
        /// <summary>
        /// A dictionary use for caching the loaded scenes
        /// </summary>
        private readonly Dictionary<object, AsyncOperationHandle> loadedScenes = new();
        
        /// <summary>
        /// Manage the loaded asset by scene and release them when those scene unloaded
        /// </summary>
        private readonly Dictionary<string, List<object>> assetsAutoUnloadByScene = new();
        
        private AsyncOperationHandle<T> InternalLoadAsync<T>(
            Dictionary<object, AsyncOperationHandle> cachedSource,
            Func<AsyncOperationHandle<T>>            handlerFunc,
            object                                   key,
            bool                                     isAutoUnload = true,
            string                                   targetScene  = ""
        )
        {
            try
            {
                if (cachedSource.TryGetValue(key, out var value)) return value.Convert<T>();

                if (this.loadingAssets.TryGetValue(key, out var asset)) return asset.Convert<T>();

                AsyncOperationHandle<T> handler = handlerFunc.Invoke();
                this.loadingAssets.Add(key, handler);

                handler.Completed += op =>
                {
                    if (isAutoUnload) this.TrackingAssetByScene(key, targetScene);
                    cachedSource.Add(key, op);
                    this.loadingAssets.Remove(key);
                };
                return handler;
            }
            catch (Exception e)
            {
                Debug.LogError($"Unable to load load assets {key}, error: {e.Message}");
                cachedSource.Remove(key);
                this.loadingAssets.Remove(key);
            }

            return default;
        }
        
        private void TrackingAssetByScene(object key, string targetScene = "")
        {
            string sceneName = string.IsNullOrEmpty(targetScene) ? SceneManager.GetActiveScene().name : targetScene;
            if (!this.assetsAutoUnloadByScene.TryGetValue(sceneName, out var listAsset))
            {
                listAsset = new();
                this.assetsAutoUnloadByScene.Add(sceneName, listAsset);
            }

            listAsset.Add(key);
        }
        
        private void CheckRuntimeKey(AssetReference aRef)
        {
            if (!aRef.RuntimeKeyIsValid()) throw new InvalidKeyException($"{nameof(aRef.RuntimeKey)} is not valid for '{aRef}'.");
        }

        #region Handle Assets
        
        public AsyncOperationHandle<T> LoadAssetAsync<T>(object key, bool isAutoUnload = true, string targetScene = "")
        {
            return this.InternalLoadAsync(this.loadedAssets, () => Addressables.LoadAssetAsync<T>(key), key, isAutoUnload, targetScene);
        }

        public List<AsyncOperationHandle<T>> PreloadAsync<T>(string targetScene = "", params object[] keys)
        {
            if (keys == null) throw new ArgumentNullException(nameof(keys));

            if (keys.Length.Equals(0)) throw new ArgumentException(nameof(keys));

            return keys.Select(o => this.LoadAssetAsync<T>(o, true, targetScene)).ToList();
        }
        
        //update later
        public AsyncOperationHandle<List<AsyncOperationHandle<object>>> LoadAssetsByLabelAsync(string label)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Handle Scene

        /// <summary>
        /// Load scene by key in addressable
        /// </summary>
        /// <param name="key"></param>
        /// <param name="loadMode"></param>
        /// <param name="activeOnLoad"></param>
        /// <returns></returns>
        public AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneMode loadMode = LoadSceneMode.Single, bool activeOnLoad = true)
        {
            return this.InternalLoadAsync(this.loadedScenes, () => Addressables.LoadSceneAsync(key, loadMode, activeOnLoad), key, true, key.ToString());
        }

        #endregion
       
    }
}