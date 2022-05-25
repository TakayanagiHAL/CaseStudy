using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EffectManager : MonoBehaviour
{
    [SerializeField] GameObject EffectPrefab;
    [SerializeField] Vector3 CreatePosV;
    [SerializeField] Transform CreatePosT;
    [SerializeField] bool Loop;
    [SerializeField] bool Chase;

    public float timer = 0.0f;
    float animTime = 0.0f;
    Animator effectAnimator;


    // Start is called before the first frame update
    void Start()
    {
        // アニメーションクリップの取得
        effectAnimator = EffectPrefab.GetComponent<Animator>();

        // アニメーション時間の取得
        animTime = effectAnimator.GetCurrentAnimatorClipInfo(0).Length;
        timer = animTime;

        // エフェクトプレハブをオフ設定
        SetActiveEffectPrefab(false);
    }


    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        // エフェクトお試し生成
        if (Keyboard.current.cKey.wasReleasedThisFrame)
        {
            SetActiveEffectPrefab(true);
        }

#endif

        // Chaseがtrueならtransformの座標に追従する
        if (Chase)
        {
            EffectPrefab.transform.position = CreatePosT.position;
        }

        // エフェクト消滅タイマー処理
        if (EffectPrefab.activeSelf)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                SetActiveEffectPrefab(false);

                timer = animTime;
            }
        }

    }


    // エフェクトの座標のセット
    public void SetCreatePosV(Vector3 setVector)
    {
        EffectPrefab.transform.position = setVector;
    }


    // エフェクトの設定
    public void SetActiveEffectPrefab(bool setBool)
    {
        EffectPrefab.SetActive(setBool);
    }
}
