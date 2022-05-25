using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GAME_STATE currentGameState = GameStateManager.Instance.CurrentGameState;
            GAME_STATE newGameState = currentGameState == GAME_STATE.GAMEPLAY
                ? GAME_STATE.PAUSE 
                : GAME_STATE.GAMEPLAY;

            GameStateManager.Instance.SetState(newGameState);
        }
    }
}
