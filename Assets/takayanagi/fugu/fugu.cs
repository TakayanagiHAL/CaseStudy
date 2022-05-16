using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fugu : MonoBehaviour
{
    [SerializeField] GameObject swimFugu;
    [SerializeField] GameObject bigFugu;
    [SerializeField] GameObject smallFugu;
    [SerializeField] float delta;
    [SerializeField] bool isHorizon;
    [SerializeField] float moveSpeed;

    public GameObject nowFugu;

    float startPos;
    float count;

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
    }

    // Update is called once per frame
    void Update()
    {
        count += moveSpeed;
        if (isSmalling)
        {
            Animator animator = nowFugu.GetComponent<Animator>();

            //animator.
        }

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

        Destroy(nowFugu);
        nowFugu = Instantiate(bigFugu, this.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;
        Destroy(nowFugu);
        nowFugu = Instantiate(smallFugu, this.transform);
        isSmalling = true;
    }
}
