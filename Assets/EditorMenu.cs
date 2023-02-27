using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;


public class EditorMenu : MonoBehaviour
{
 
    private static int _x = 5;


   /* static int x
    {
        get => _x;
        set => _x = Mathf.Clamp(value, 0, 100);
    }

    [MenuItem("Tools/Property Demo")]


    static void PropertyDemo()
    {
        x = -99;

        Debug.Log(x);
    }*/


    [MenuItem("Tools/Count Scene Number")]


    static void CountSceneNumber()
    {
        Debug.Log(GetSceneAssets().Count);
    }
    static string[] searchInFolders = new[] { "Assets/Scenes/" };
    

    static List<SceneAsset> GetSceneAssets()
    {
        string[] sceneGuids = AssetDatabase.FindAssets("t:SceneAsset", searchInFolders);
        var sceneAssets = new List<SceneAsset>();
        foreach (var sceneGuid in sceneGuids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(sceneGuid);
            sceneAssets.Add(AssetDatabase.LoadAssetAtPath<SceneAsset>(assetPath));
        }
        return sceneAssets;
    }
    [MenuItem("Tools/Update Scene Assets")]
    static void UpdateSceneAssets() 
    {
        
        if (!AssetDatabase.IsValidFolder(Path.Combine("Assets", "ScriptableObjects"))); 
        {
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects"); 
        } 



        foreach (var sceneAsset in GetSceneAssets())
        { 
            var sceneData = ScriptableObject.CreateInstance<LevelData>();
            sceneData.sceneAsset = sceneAsset; 
            string assetPath = Path.Combine("Assets", "ScriptableObjects", sceneData.sceneName + ".asset"); 
            AssetDatabase.CreateAsset(sceneData, assetPath); 
        }
    }
}
#endif
