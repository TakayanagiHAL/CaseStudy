using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EffectManager : MonoBehaviour
{
    [SerializeField] GameObject EffectPrefab;
    [SerializeField] Vector3 CreatePos;

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
#endif


    }

    // エフェクトの生成
    void CreateEffect()
    {
        // インスタンス生成
        Instantiate(EffectPrefab, CreatePos, Quaternion.identity);
    }

}
