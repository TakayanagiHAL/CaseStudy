using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SceneTransitionFromDatabase : MonoBehaviour
{
    public ScenesData sceneDatabase;
    public SCENE_TYPE moveToSceneType;

    public Animator fadeAnimator;

    public void FadeToStage()
    {
        if (SystemInfo.deviceType != DeviceType.Handheld)
        {
            SoundManager.instance.PlaySE("クリック");
            StartCoroutine(FadeTo());
        }
    }

    public void FadeToStageMobile()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            SoundManager.instance.PlaySE("クリック");
            StartCoroutine(FadeTo());
        }
    }

    public void Restart()
    {
        SoundManager.instance.PlaySE("クリック");
        StartCoroutine(FadeToRestart());
    }

    IEnumerator FadeTo()
    {
        fadeAnimator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(fadeAnimator.GetCurrentAnimatorClipInfo(0).Length);
        sceneDatabase.MoveToLevel(moveToSceneType);
    }
    IEnumerator FadeToRestart()
    {
        fadeAnimator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(fadeAnimator.GetCurrentAnimatorClipInfo(0).Length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}