using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class player : MonoBehaviour
{
    [SerializeField] float startRadian;

    [SerializeField] float rotateSpeed;

    [SerializeField] float impactPower;

    [SerializeField] float addPowerMouse;
    [SerializeField] lifeUI lifeUI;
    [SerializeField] Animator kurage_anim;

    [SerializeField] GameObject[] chargeEF;
    [SerializeField] GameObject[] hitEF;
    [SerializeField] GameObject[] moveEF;

    PlayerInput input;

    InputAction rotateR, rotateL,Triger;

    public bool useMouse;

    public float power =0;

    Rigidbody2D Rigidbody2D;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        // Subscribe to the gamestate manager
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        // Unsubscribe to the gamestate manager to prevent memory leaks
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }


    // Start is called before the first frame update
    void Start()
    {
        var actionMap = input.currentActionMap;

        rotateR = actionMap["RotateRight"];
        rotateL = actionMap["RotateLeft"];
        Triger = actionMap["ChargePower"];
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        // エフェクトお試し生成
        if (Keyboard.current.digit3Key.wasReleasedThisFrame)
        {
            chargeEF[0].SetActive(true);
        }

        if (Keyboard.current.digit4Key.wasReleasedThisFrame)
        {
            chargeEF[1].SetActive(true);
        }

        if (Keyboard.current.digit5Key.wasReleasedThisFrame)
        {
            chargeEF[2].SetActive(true);
        }

        if (Keyboard.current.digit6Key.wasReleasedThisFrame)
        {
            chargeEF[3].SetActive(true);
        }
        if (Keyboard.current.digit7Key.wasReleasedThisFrame)
        {
            chargeEF[4].SetActive(true);
        }
#endif


        if (rotateR.ReadValue<float>() > 0)
        {
            transform.RotateAroundLocal(Vector3.back, rotateSpeed);

            moveEF[0].SetActive(true);

            moveEF[1].SetActive(false);

            Debug.Log("input rotateR");
        }else if (rotateL.ReadValue<float>() > 0)
        {
            transform.RotateAroundLocal(Vector3.back, -rotateSpeed);

            moveEF[1].SetActive(true);
            moveEF[0].SetActive(false);
            Debug.Log("input rotateL");
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                moveEF[i].SetActive(false);
            }
        }

        if (useMouse)
        {
            var mouse = Mouse.current;
            Vector2 MousePos = mouse.position.ReadValue();
            MousePos.x -= Screen.width / 2;
            MousePos.y -= Screen.height / 2;
            //Debug.Log(MousePos);

            transform.rotation = Quaternion.FromToRotation(Vector3.up, MousePos);

            if (mouse.leftButton.isPressed)
            {
                kurage_anim.SetBool("Shot", true);
                power += addPowerMouse;
            }

            if (mouse.leftButton.wasReleasedThisFrame)
            {
                Inpact();
                power = 0.0f;
            }
        }
        else
        {
            if (Triger.ReadValue<float>() <= 0)
            {
                if (power < 0.2) return;
                chargeEF[(int)(power * 5) - 1].SetActive(false);
                Inpact();
                power = 0.0f;
            }

            if (power < Triger.ReadValue<float>())
            {
                if (Triger.ReadValue<float>() < 0.2) return;
                kurage_anim.SetBool("Shot", true);
                if (power >= 0.2)
                {
                    if ((int)(power * 5) != (int)(Triger.ReadValue<float>() * 10 / 2))
                    {
                        chargeEF[(int)(power * 5) - 1].SetActive(false);

                    }
                }
                power = Triger.ReadValue<float>();
                power = ((int)(power * 10 / 2)) * 0.2f;
                chargeEF[(int)(power * 5) - 1].SetActive(true);
                Debug.Log(power);
            }
        }
       
    }

    void Inpact()
    {
        if (power < 0.2) return;

        Vector2 force = new Vector2(Mathf.Cos(transform.localEulerAngles.z * 3.14f / 180.0f), Mathf.Sin(transform.localEulerAngles.z * 3.14f / 180.0f));
        Rigidbody2D.AddForce(force * power * impactPower, ForceMode2D.Impulse);

        kurage_anim.SetBool("Shot",false);

        if(useMouse)
        {
            hitEF[0].GetComponent<EffectPrefab>().EffectON();
        }
        else
        {
            hitEF[(int)((power * 5) - 1)].GetComponent<EffectPrefab>().EffectON();
        }
        
        this.gameObject.transform.GetChild(2).gameObject.GetComponent<Bubble>().SetBubbleAnimatorHitTrigger();

        SoundManager.instance.PlaySE("クラゲヒット");

        Debug.Log("Inpact");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            lifeUI.LifeDown();
            SoundManager.instance.PlaySE("破裂");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hoimi")
        {
            lifeUI.LifeUp();
            SoundManager.instance.PlaySE("回復");
        }
    }

    // Listen for the gamestate event
    private void OnGameStateChanged(GAME_STATE newGameState)
    {
        if (newGameState != GAME_STATE.GAMEPLAY)
        {
            Rigidbody2D.simulated = false;
            enabled = false;
        }
        else
        {
            enabled = true;
            Rigidbody2D.simulated = true;
        }

    }
}
