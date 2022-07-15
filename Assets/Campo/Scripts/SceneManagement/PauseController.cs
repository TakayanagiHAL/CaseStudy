using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PauseController : MonoBehaviour
{
    PlayerInput input;
    InputAction pause;

    private void Start()
    {

        input = FindObjectOfType<PlayerInput>();
        var actionMap = input.currentActionMap;
        if(actionMap != null) pause = actionMap["Pause"];

    }
    void Update()
    {
        if (pause == null)
        {
            var actionMap = input.currentActionMap;
            if(actionMap == null) return;

            pause = actionMap["Pause"];
        }

        if (pause.triggered)
        {
            PoseSwitch();
        }
    }

    public void PoseSwitch()
    {
        if (GameStateManager.Instance.CurrentGameState != GAME_STATE.GAMEEND)
        {

            GAME_STATE currentGameState = GameStateManager.Instance.CurrentGameState;
            GAME_STATE newGameState = currentGameState == GAME_STATE.GAMEPLAY
                ? GAME_STATE.PAUSE
                : GAME_STATE.GAMEPLAY;

            GameStateManager.Instance.SetState(newGameState);
        }
    }
}
