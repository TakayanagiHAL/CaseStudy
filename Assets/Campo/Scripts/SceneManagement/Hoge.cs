using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoge : MonoBehaviour
{
    public ScenesData scenesData;
    bool pressed;

    public Animator m_animator;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pressed)
        {
            pressed = true;
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }


    IEnumerator LoadLevel()
    {
        m_animator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(m_animator.GetCurrentAnimatorClipInfo(0).Length);

        scenesData.NextLevel();
    }
}
