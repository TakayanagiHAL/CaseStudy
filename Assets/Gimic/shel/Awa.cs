using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false);
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySE("‰ñ•œ");
            Debug.Log("get!!");
        }
    }
}
