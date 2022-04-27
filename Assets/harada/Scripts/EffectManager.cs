using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EffectManager : MonoBehaviour
{
    [SerializeField] GameObject EffectPrefab;
    [SerializeField] Vector3 CreatePos;
    [SerializeField] bool Loop;

    GameObject EffectObject;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        // エフェクトお試し生成
        if (Keyboard.current.cKey.wasReleasedThisFrame)
        {
            CreateEffect();
        }

        // エフェクトお試し消去
        if (Keyboard.current.dKey.wasReleasedThisFrame)
        {
            DestroyEffect();
        }
#endif


    }

    // エフェクトの生成
    void CreateEffect()
    {
        // インスタンス生成
        EffectObject = Instantiate(EffectPrefab, CreatePos, Quaternion.identity);

        // ループ設定がオフならばアニメーション終了でインスタンスを消去
        if(!Loop)
        {
            // インスタンス消去
            DestroyEffect();
        }
    }


    // エフェクトの消去
    void DestroyEffect()
    {
        // インスタンス消去
        GameObject.Destroy(EffectObject, 1.0f);
    }

}
