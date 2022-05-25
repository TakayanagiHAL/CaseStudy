using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLevelTransition : MonoBehaviour
{
    public ScenesData scenesData;
    public Animator animator;

    public void MoveToLevel()
    {
        StartCoroutine(LoadLevel());
    }


    IEnumerator LoadLevel()
    {
        animator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
    }

    
}
