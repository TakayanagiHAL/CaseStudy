using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanicCurrent : MonoBehaviour
{
    public Vector2 OceanCurrentDir;

    private Rigidbody2D playerRB;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerRB = collision.gameObject.GetComponent<Rigidbody2D>();

            playerRB.AddForce(OceanCurrentDir);
        }
    }
}
