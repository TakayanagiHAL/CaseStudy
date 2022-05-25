using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class GoalManagement : MonoBehaviour
{
    // ステージ名前と番号
    private string sceneName;
    private string levelNum;

    private void Start()
    {
        //　ステージ名前と番号ゲット
        sceneName = SceneManager.GetActiveScene().name;
        levelNum = sceneName.Replace("stage", "");
    }

    //　判定あれば
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //　プレイヤーがゴールに到達した
        if (collision.tag == "Player")
        {
            //　PlayerPrefsを設定
            PlayerPrefs.SetInt("Stage_" + levelNum + "_Clear", 1);
            Debug.Log("レベルクリア！PlayerPrefs　Stage_" + levelNum + "_Clear　を１に設定させてる");

            //　ゲームクリア

        }
    }
}
