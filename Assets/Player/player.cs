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
    [SerializeField] GameObject bubbleRecoveryEF;

    PlayerInput input;

    InputAction rotateR, rotateL,Triger;

    public float power =0;

    public bool isCharge;

    Rigidbody2D Rigidbody2D;

    bool rotateRight = false;
    bool rotateLeft = false;

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
        if (rotateR.ReadValue<float>() > 0)
        {
            rotateRight = true;
        }
        else if (rotateL.ReadValue<float>() > 0)
        {
            rotateLeft = true;
        }

        if (rotateRight)
        {
            transform.RotateAroundLocal(Vector3.back, rotateSpeed);

            moveEF[0].SetActive(true);

            moveEF[1].SetActive(false);

            Debug.Log("input rotateR");
        }else if (rotateLeft)
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

        rotateRight = false;
        rotateLeft  = false;


        if (isCharge)
        {
            kurage_anim.SetBool("Shot", true);
            if (power >= 0.2)
            {
                if ((int)(power * 5) != (int)((power + addPowerMouse) * 10 / 2))
                {
                    chargeEF[(int)(power * 5) - 1].SetActive(false);

                }
            }

            power += addPowerMouse;

            chargeEF[(int)(power * 5) - 1].SetActive(true);

            if (power > 1.0f) power = 1.0f;
        }
      

        if (Triger.ReadValue<float>() <= 0)
        {
            if (isCharge)
            {
                return;
            }
            if (power < 0.2) return;
           
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

    public void Inpact()
    {
        if (power < 0.2) return;

        chargeEF[(int)(power * 5) - 1].SetActive(false);

        Vector2 force = new Vector2(Mathf.Cos(transform.localEulerAngles.z * 3.14f / 180.0f), Mathf.Sin(transform.localEulerAngles.z * 3.14f / 180.0f));
        Rigidbody2D.AddForce(force * power * impactPower, ForceMode2D.Impulse);

        kurage_anim.SetBool("Shot",false);

        hitEF[(int)((power * 5) - 1)].GetComponent<EffectPrefab>().EffectON();       
        
        this.gameObject.transform.GetChild(2).gameObject.GetComponent<Bubble>().SetBubbleAnimatorHitTrigger();

        SoundManager.instance.PlaySE("ƒNƒ‰ƒQƒqƒbƒg");

        Debug.Log("Inpact");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            lifeUI.LifeDown();
            SoundManager.instance.PlaySE("”j—ô");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hoimi")
        {
            bubbleRecoveryEF.GetComponent<EffectPrefab>().SetEffectRotation();
            bubbleRecoveryEF.GetComponent<EffectPrefab>().EffectON();

            lifeUI.LifeUp();
            SoundManager.instance.PlaySE("‰ñ•œ");
        }
    }

    // Listen for the gamestate event
    private void OnGameStateChanged(GAME_STATE newGameState)
    {
        Debug.Log("Gamestate Start");
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

        if (newGameState == GAME_STATE.GAMESTART)
        {
            Debug.Log("Input false");
            input.enabled = false;
        }
        else if(newGameState == GAME_STATE.GAMEPLAY)
        {
            Debug.Log("Input true");
            input.enabled = true;
        }

    }

    public void RotateRight()
    {
        rotateRight = true;
    }

    public void RotateLeft()
    {
        rotateLeft = true;
    }
}
