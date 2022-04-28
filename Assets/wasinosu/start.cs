using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class start : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerObj;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = Instantiate(PlayerObj, transform.position, Quaternion.identity);
        //PlayerObj.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
            ReSpawn();
        }
    }

    void ReSpawn()
    {
        Player.transform.position = transform.position;
    }
}
