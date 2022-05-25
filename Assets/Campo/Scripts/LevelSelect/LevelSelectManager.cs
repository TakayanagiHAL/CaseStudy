using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public int levelToCheck;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Level " + levelToCheck + " Clear") == 1 || levelToCheck == 0)
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
