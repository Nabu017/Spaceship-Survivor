using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using System;

public class SceneLoaderAdressables : MonoBehaviour
{
    private string sceneName;


    public void Load(string sceneName)
    {
        this.sceneName = sceneName;
        string label = "Scene" + sceneName.Last();

        Addressables.LoadAssetsAsync<UnityEngine.Object>(new List<string>() { label },
            x => { }, Addressables.MergeMode.Union).Completed += Sceneloader_Completed;
    }

    private void Sceneloader_Completed(AsyncOperationHandle<IList<UnityEngine.Object>> obj)
    {
        Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }

  public void Back()
    {
        Addressables.LoadSceneAsync("AssetMain", LoadSceneMode.Single);
    }
}
