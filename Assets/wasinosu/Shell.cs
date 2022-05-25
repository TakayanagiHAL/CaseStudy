using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    Transform bubblePool;

    private float cooltime = 3.0f;
    private Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        bubblePool = new GameObject("bubblePool").transform;
        bubblePool.parent = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        cooltime -= Time.deltaTime;
        if(cooltime < 0)
        {
            var awa = SetObject();
            rd = awa.GetComponent<Rigidbody2D>();
            Vector3 force = new Vector3(0.0f, 1.0f, 0.0f);
            rd.AddForce(force, ForceMode2D.Force);
            cooltime = 3.0f;
        }
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
}
