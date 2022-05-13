using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlayBGM("Q");
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlayBGM("W");
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlaySE("C");
        }

        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlaySE("V");
        }
    }
}
