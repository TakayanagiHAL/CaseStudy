using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fugu_HitEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 point = collision.GetContact(0).point;

            this.gameObject.GetComponent<EffectManager>().SetCreatePosV(point);
            this.gameObject.GetComponent<EffectManager>().SetActiveEffectPrefab(true);
        }
    }
}
