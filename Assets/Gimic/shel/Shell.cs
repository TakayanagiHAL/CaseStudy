using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    Transform bubblePool;

    private float opentime = 1.0f;
    private Rigidbody2D rd;
    private Animator animeter;
    private bool isOpen = false;
    private bool isAnimation = false;
    // Start is called before the first frame update
    void Start()
    {
        bubblePool = new GameObject("bubblePool").transform;
        bubblePool.parent = this.gameObject.transform;

        animeter = GetComponent<Animator>();
        animeter.SetBool("open", false);
    }

    // Update is called once per frame
    void Update()
    {
        opentime -= Time.deltaTime;

        if(!isOpen && opentime < 0)
        {
            isOpen = true;
            animeter.SetBool("open", true);
        }
        //ChangeAnimation();
    }

    GameObject SetObject()
    {
        foreach(Transform t in bubblePool)
        {
            if(!t.gameObject.activeSelf)
            {
                t.SetPositionAndRotation(transform.position, Quaternion.identity);
                t.gameObject.SetActive(true);
                return t.gameObject;
            }
        }

        return Instantiate(bubble, transform.position, Quaternion.identity,bubblePool);
    }

    public void SetBubble()
    {
        var awa = SetObject();
        rd = awa.GetComponent<Rigidbody2D>();
        Vector3 force = new Vector3(0.0f, 1.0f, 0.0f);
        rd.AddForce(force, ForceMode2D.Force);
    }

    public void SetClose()
    {
        animeter.SetBool("open", false);
    }

    public void EndClose()
    {
        isOpen = false;
        opentime = 1.0f;
    }
}
