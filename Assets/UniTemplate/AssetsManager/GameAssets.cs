namespace UniTemplate.AssetsManager
{
    using System;
    using System.Collections.Generic;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.ResourceManagement.ResourceProviders;
    using UnityEngine.SceneManagement;

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
        AsyncOperationHandle<T> LoadAssetAsync<T>(object key, bool isAutoUnload = true);
        
        /// <summary>
        /// load screen in addressable by key
        /// </summary>
        /// <param name="key">The key of location of the addressable</param>
        /// <param name="loadMode"></param>
        /// <param name="activeOnLoad"></param>
        /// <returns></returns>
        AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneMode loadMode = LoadSceneMode.Single, bool activeOnLoad = true);
        
        /// <summary>
        /// load list assets by label
        /// </summary>
        /// <param name="targetScene"></param>
        /// <param name="label"></param>
        /// <param name="autoUnload"></param>
        /// <returns></returns>
        AsyncOperationHandle<IList<AsyncOperationHandle<Object>>> PreloadByLabelAsync(string targetScene, string label, bool autoUnload = true);
    }
    
    
    public class GameAssets : IGameAssets
    {
        public List<AsyncOperationHandle<T>> PreloadAsync<T>(string targetScene = "", params object[] keys)
        {
            throw new NotImplementedException();
        }
        
        public AsyncOperationHandle<List<AsyncOperationHandle<object>>> LoadAssetsByLabelAsync(string label)
        {
            throw new NotImplementedException();
        }
        
        public AsyncOperationHandle<T> LoadAssetAsync<T>(object key, bool isAutoUnload = true)
        {
            throw new NotImplementedException();
        }
        
        public AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneMode loadMode = LoadSceneMode.Single, bool activeOnLoad = true)
        {
            throw new NotImplementedException();
        }
        
        public AsyncOperationHandle<IList<AsyncOperationHandle<object>>> PreloadByLabelAsync(string targetScene, string label, bool autoUnload = true)
        {
            throw new NotImplementedException();
        }
    }
}