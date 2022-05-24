using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GameManagement : MonoBehaviour
{
    public Canvas[] canvas;
    public bool[] bools;

    public Timer timer;
    public lifeUI life;

    // Start is called before the first frame update
    void Start()
    {
       
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
    }
}
