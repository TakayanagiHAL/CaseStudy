using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[ExecuteInEditMode]
public class GameManagement : MonoBehaviour
{
    public Canvas[] canvas;
    public bool[] bools;

    public Timer timer;
    public lifeUI life;

    PlayerInput input;
    InputAction pose;

    EventSystem eventSystem;

    bool isIn = false;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = FindObjectOfType<EventSystem>();
        input = FindObjectOfType<PlayerInput>();

        var actionMap = input.currentActionMap;

        pose = actionMap["Pose"];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bools.Length; i++)
        {

                if (bools[i] != canvas[i].enabled)
                {
                    canvas[i].enabled = bools[i];
                    if (bools[i]&&i!=0)
                    {
                        GameObject button = canvas[i].transform.GetChild(0).GetComponentInChildren<Button>().gameObject;
                        if (button)
                        {
                            eventSystem.SetSelectedGameObject(button);
                        }
                    }
                }
            
        }
        if(pose.ReadValue<float>() > 0)
        {
            if (!isIn)
            {
                bools[3] = !bools[3];
            }
        }
        
        if (pose.ReadValue<float>() > 0)
        {
            isIn = true;
        }
        else
        {
            isIn = false;
        }
    }
}
