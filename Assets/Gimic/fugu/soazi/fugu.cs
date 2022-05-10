using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fugu : MonoBehaviour
{
    [SerializeField] float delta;
    [SerializeField] bool isHorizon;
    [SerializeField] float moveSpeed;

    float startPos;
    float count;

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
