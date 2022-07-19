using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    PauseController pauseController;
    // Start is called before the first frame update
    void Start()
    {
        pauseController = FindObjectOfType<PauseController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtunDown()
    {
        if(pauseController==null) pauseController = FindObjectOfType<PauseController>();

        pauseController.PoseSwitch();

        Debug.Log("PauseButton");
    }
}
