using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [Tooltip("{world}_{ stage}å`éÆÇ≈Ç†ÇÈÇ±Ç∆ÅB\n  ó·ÅF1_1")]
    public string levelToCheck;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Stage_" + levelToCheck + "_Clear") == 1 || levelToCheck == "0_0")
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }

        //PlayerPrefs.
    }
}
