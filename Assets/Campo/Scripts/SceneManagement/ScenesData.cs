using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scene_Database", menuName = "Scene Data/Database")]
public class ScenesData : ScriptableObject
{
    [System.Serializable]
    public class SCENE_INFO
    {
       public string SCENETYPE;
       public string SCENENAME;
    }

    public List<SCENE_INFO> sceneInfo;
    public SCENE_TYPE currentScene;

    public void MoveToLevel(SCENE_TYPE sceneType)
    {
        currentScene = sceneType;
        SceneManager.LoadSceneAsync(sceneInfo[(int)sceneType].SCENENAME);
    }
}
