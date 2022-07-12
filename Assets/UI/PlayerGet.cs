using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGet : MonoBehaviour
{
    player player;

    bool turnRight = false;
    bool turnLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnLeft)
        {
            player.RotateLeft();
        }

        if (turnRight)
        {
            player.RotateRight();
        }
    }

    public void SetTurnRight(bool triger)
    {
        turnRight = triger;
    }

    public void SetTurnLeft(bool triger)
    {
        turnLeft = triger;
    }

    public void SetCharge()
    {
        player.isCharge = true;
    }

    public void SetInpalse()
    {
        player.isCharge = false;
        player.power = ((int)(player.power * 10 / 2)) * 0.2f;
        player.Inpact();
        player.power = 0.0f;
        Debug.Log("Inpalsed poser " + player.power);
    }
}
