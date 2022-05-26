using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransitionFromDatabase : MonoBehaviour
{
    public ScenesData sceneDatabase;
    public SCENE_TYPE moveToSceneType;

    public Animator fadeAnimator;

    public void FadeToStage()
    {
        StartCoroutine(FadeTo());
    }

    public void Restart()
    {
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
