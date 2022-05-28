using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class fugu_HitEffect : MonoBehaviour
{
    [SerializeField] GameObject MoveEffect;
    [SerializeField] float HitEffectAdjustX;
    [SerializeField] float HitEffectAdjustY;

    Animator MoveEffectAnimator;
    bool last = false;
    float timer;
    float animTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        MoveEffectAnimator = MoveEffect.GetComponent<Animator>();

        MoveEffect.SetActive(false);

        timer = animTime;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

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

        if (Keyboard.current.mKey.wasReleasedThisFrame)
        {
            SetMoveEffect();
        }
        if (Keyboard.current.oKey.wasReleasedThisFrame)
        {
            SetMoveEffectAnimatorLastTrigger();
        }
#endif


        // エフェクト消滅タイマー処理
        if (last)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                MoveEffect.SetActive(false);

                timer = animTime;
                last = false;
            }
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


    public void SetMoveEffect()
    {
        if (MoveEffect.activeSelf) return;

        MoveEffect.SetActive(true);
    }


    public void SetMoveEffectAnimatorLastTrigger()
    {
        MoveEffectAnimator.SetTrigger("last");

        last = true;
    }
}
