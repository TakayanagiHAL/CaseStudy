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


    GameObject EffectObject;
    Animator effectAnimator;
    AnimatorClipInfo[] effectAnimatorClipInfo;


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
            CreateEffect(90.0f);
        }

        // エフェクトお試し消去
        if (Keyboard.current.dKey.wasReleasedThisFrame)
        {
            DestroyEffect();
        }
#endif

        // Chaseがtrueならtransformの座標に追従する
        if(Chase && EffectObject != null)
        {
            EffectObject.transform.position = CreatePosT.position;
        }


    }

    // エフェクトの生成
    // effectRotate...回転させたい角度の値（Z回転）
    public void CreateEffect(float effectRotate)
    {
        // インスタンス生成
        // Transformが設定されていなければ指定した座標で生成
        if (CreatePosT != null)
        {
            EffectObject = Instantiate(EffectPrefab, CreatePosT.transform.position, Quaternion.Euler(0, 0, effectRotate));
        }
        else
        {
            EffectObject = Instantiate(EffectPrefab, CreatePosV, Quaternion.Euler(0, 0, effectRotate));
        }

        
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
        // アニメーションクリップの取得
        effectAnimator = EffectObject.GetComponent<Animator>();
        effectAnimatorClipInfo = effectAnimator.GetCurrentAnimatorClipInfo(0);

        //Debug.Log(effectAnimatorClipInfo[0].clip.length);

        // インスタンス消去
        GameObject.Destroy(EffectObject, effectAnimatorClipInfo[0].clip.length);
    }

}
