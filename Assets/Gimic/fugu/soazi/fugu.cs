using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class fugu : MonoBehaviour
{
    [SerializeField] GameObject fugu_sprite;
    [SerializeField] float delta;
    [SerializeField] bool isHorizon;
    [SerializeField] float moveSpeed;
    [SerializeField] bool isStartVector;
    [SerializeField] bool isChangeVector;

    float startPos;
    float count;
    float tempScaleX;

    Animator animator;

    bool isSmalling = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isHorizon)
        {
            startPos = transform.position.x;
        }
        else
        {
            startPos = transform.position.y;
        }

        animator = this.GetComponentInChildren<Animator>();

        tempScaleX = fugu_sprite.transform.localScale.x;

        if (isStartVector)
        {
            fugu_sprite.transform.localScale = new Vector3(-tempScaleX, fugu_sprite.transform.localScale.y, fugu_sprite.transform.localScale.z);
        }
        else
        {
            fugu_sprite.transform.localScale = new Vector3(tempScaleX, fugu_sprite.transform.localScale.y, fugu_sprite.transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        count += moveSpeed;

        if (isHorizon)
        {
            transform.position = new Vector3(Mathf.Sin(count) * delta + startPos, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Mathf.Sin(count) * delta + startPos, transform.position.z);
        }

        if (delta > 0.0f && isChangeVector)
        {
            if (Mathf.Cos(count) > 0)
            {
                fugu_sprite.transform.localScale = new Vector3(-tempScaleX, fugu_sprite.transform.localScale.y, fugu_sprite.transform.localScale.z);
            }
            else
            {
                fugu_sprite.transform.localScale = new Vector3(tempScaleX, fugu_sprite.transform.localScale.y, fugu_sprite.transform.localScale.z);
            }

            if ((Mathf.Sin(count) >= 0 && Mathf.Cos(count) < 0) || (Mathf.Sin(count) < 0 && Mathf.Cos(count) >= 0))
            {
                this.gameObject.transform.GetChild(0).GetComponent<fugu_HitEffect>().SetMoveEffect();
            }
            else
            {
                this.gameObject.transform.GetChild(0).GetComponent<fugu_HitEffect>().SetMoveEffectAnimatorLastTrigger();
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        animator.SetBool("IsBig", true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;
        animator.SetBool("IsBig", false);
    }
}
