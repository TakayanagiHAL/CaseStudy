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

    PlayerInput input;

    InputAction rotateR, rotateL,Triger;

    public bool useMouse;

    public float power =0;

    Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        input = GetComponent<PlayerInput>();

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
            transform.RotateAroundLocal(Vector3.back, rotateSpeed);

            Debug.Log("input rotateR");
        }

        if (rotateL.ReadValue<float>() > 0)
        {
            transform.RotateAroundLocal(Vector3.back, -rotateSpeed);

            Debug.Log("input rotateL");
        }

        if (useMouse)
        {
            var mouse = Mouse.current;
            Vector2 MousePos = mouse.position.ReadValue();
            MousePos.x -= Screen.width / 2;
            MousePos.y -= Screen.height / 2;
            Debug.Log(MousePos);

            transform.rotation = Quaternion.FromToRotation(Vector3.up, MousePos);

            if (mouse.leftButton.isPressed)
            {
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
                Inpact();
                power = 0.0f;
            }

            if (power < Triger.ReadValue<float>())
            {
                power = Triger.ReadValue<float>();
                power = ((int)(power * 10 / 2)) * 0.2f;
                Debug.Log(power);
            }
        }
       
    }

    void Inpact()
    {
        Vector2 force = new Vector2(Mathf.Cos(transform.localEulerAngles.z * 3.14f / 180.0f), Mathf.Sin(transform.localEulerAngles.z * 3.14f / 180.0f));
        Rigidbody2D.AddForce(force * power * impactPower, ForceMode2D.Impulse);

        kurage_anim.SetTrigger("Shot");

        // 泡のエフェクト再生
        this.gameObject.transform.GetChild(2).gameObject.GetComponent<Bubble>().SetBubbleAnimatorHitTrigger();

        Debug.Log("Inpact");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            lifeUI.LifeDown();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hoimi")
        {
            lifeUI.LifeUp();
        }
    }


}
