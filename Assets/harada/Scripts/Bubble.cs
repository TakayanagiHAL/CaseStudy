using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bubble : MonoBehaviour
{
    private Animator bubbleAnimator;

    // Start is called before the first frame update
    void Start()
    {
        bubbleAnimator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void SetBubbleAnimatorHit(bool isHit)
    {
        bubbleAnimator.SetBool("Hit", isHit);
    }


    public void SetBubbleAnimatorHitTrigger()
    {
        bubbleAnimator.SetTrigger("HitTrigger");
    }
}
