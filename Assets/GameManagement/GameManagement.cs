using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    bool isIn = false;

    // Start is called before the first frame update
    void Start()
    {
        input = FindObjectOfType<PlayerInput>();

        var actionMap = input.currentActionMap;

        pose = actionMap["Pose"];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bools.Length; i++)
        {
            foreach (Canvas c in canvas)
            {
                if (c != canvas[i])
                {
                    canvas[i].enabled = bools[i];
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
