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
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SoundManager.instance.PlayBGM("タイトル");
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SoundManager.instance.PlayBGM("メイン");
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            SoundManager.instance.PlayBGM("セレクト");
        }
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            SoundManager.instance.PlayBGM("クリア");
        }

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlaySE("クラゲヒット");
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlaySE("ゲームオーバー");
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlaySE("カウントダウン");
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlaySE("フグハリセン");
        }
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlaySE("クリック");
        }
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlaySE("かいふく");
        }
        if (Keyboard.current.uKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlaySE("はれつ");
        }
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            SoundManager.instance.PlaySE("かいりゅう");
        }
    }
}
