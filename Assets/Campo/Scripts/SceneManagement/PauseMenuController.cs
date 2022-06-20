using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameManagement gameManager;

    private void Awake()
    {
        // Subscribe to the gamestate manager
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        // Unsubscribe to the gamestate manager to prevent memory leaks
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    // Listen for the gamestate event
    private void OnGameStateChanged(GAME_STATE newGameState)
    {
        if (newGameState == GAME_STATE.PAUSE)
        {
            gameManager.bools[3] = true;
        }
        else
        {
            gameManager.bools[3] = false;
        }
    }
}
