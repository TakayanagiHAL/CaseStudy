using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SceneTransitionFromDatabase : MonoBehaviour
{
    public ScenesData sceneDatabase;
    public SCENE_TYPE moveToSceneType;

    public Animator fadeAnimator;

    public void FadeToStage()
    {
        StartCoroutine(FadeTo());
    }

    IEnumerator FadeTo()
    {
        fadeAnimator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(fadeAnimator.GetCurrentAnimatorClipInfo(0).Length);
        sceneDatabase.MoveToLevel(moveToSceneType);
    }
}
