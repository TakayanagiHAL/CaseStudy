using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverManager : MonoBehaviour
{
    lifeUI lifeUI;
    GameManagement gameManagement;
    [SerializeField] float delay;

    // Start is called before the first frame update
    void Start()
    {
        lifeUI = FindObjectOfType<lifeUI>();
        gameManagement = FindObjectOfType<GameManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeUI.GetLife()<=0)
        {
            Debug.Log("nowOVER");
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                gameManagement.bools[0] = false;
                gameManagement.bools[2] = true;
                GameStateManager.Instance.SetState(GAME_STATE.GAMEEND);
            }
        }
    }
}
