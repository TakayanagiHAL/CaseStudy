using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrefab : MonoBehaviour
{
    bool NoChase;
    float timer;
    float animTime;
    Vector3 noChasePosition;


    // Start is called before the first frame update
    void Start()
    {
        // アニメーション時間を取得
        animTime = this.gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        timer = animTime;
        Debug.Log(animTime);

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // エフェクト消滅タイマー処理
        if (this.gameObject.activeSelf)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                this.gameObject.SetActive(false);

                timer = animTime;
            }
        }

        // NoChaseがtrueならtransformの座標に追従する
        if (NoChase && noChasePosition != null)
        {
            this.gameObject.transform.position = noChasePosition;
        }
    }


    public void EffectON()
    {
        this.gameObject.SetActive(true);
    }


    public void SetEffectPosition(Vector3 setVector)
    {
        NoChase = true;

        noChasePosition = setVector;
    }
}
