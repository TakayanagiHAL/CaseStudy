using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas clearCanvas;
    [SerializeField] Canvas overCanvas;
    [SerializeField] Canvas poseCanvas;
    [SerializeField] Timer timer;
    [SerializeField] lifeUI life;
    // Start is called before the first frame update
    void Start()
    {
        clearCanvas.enabled = false;
        overCanvas.enabled = false;
        poseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
