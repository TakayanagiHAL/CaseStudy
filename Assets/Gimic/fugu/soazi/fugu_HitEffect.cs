using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class fugu_HitEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // エフェクトお試し生成
        if (Keyboard.current.digit0Key.wasReleasedThisFrame)
        {
            this.gameObject.GetComponent<EffectPrefabManager>().EffectNumON(0);
        }

        if (Keyboard.current.digit1Key.wasReleasedThisFrame)
        {
            this.gameObject.GetComponent<EffectPrefabManager>().EffectNumON(1);
        }

        if (Keyboard.current.digit2Key.wasReleasedThisFrame)
        {
            this.gameObject.GetComponent<EffectPrefabManager>().EffectNumON(2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 point = collision.GetContact(0).point;

            this.gameObject.transform.GetChild(0).GetComponent<EffectPrefab>().SetEffectPosition(point);
            this.gameObject.transform.GetChild(0).GetComponent<EffectPrefab>().EffectON();
        }
    }
}
