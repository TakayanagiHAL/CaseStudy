using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class fugu : MonoBehaviour
{
    [SerializeField] float delta;
    [SerializeField] bool isHorizon;
    [SerializeField] float moveSpeed;
    [SerializeField] bool isVector;

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

        tempScaleX = transform.localScale.x;

        if (isVector)
        {
            transform.localScale = new Vector3(-tempScaleX, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(tempScaleX, transform.localScale.y, transform.localScale.z);
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

        if(delta > 0.0f)
        {
            if (Mathf.Cos(count) > 0)
            {
                transform.localScale = new Vector3(-tempScaleX, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(tempScaleX, transform.localScale.y, transform.localScale.z);
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
