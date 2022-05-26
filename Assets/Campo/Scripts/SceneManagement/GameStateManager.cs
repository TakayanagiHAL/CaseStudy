using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
    private static GameStateManager _instance;

    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameStateManager();
            }
            return _instance;
        }
    }

    public GAME_STATE CurrentGameState { get; private set; }

    public delegate void GameStateChangeHandler(GAME_STATE newGameState);
    public event GameStateChangeHandler OnGameStateChanged;

    public void SetState(GAME_STATE newGameState)
    {
        if (newGameState ==  CurrentGameState)
        {
            return;
        }

        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }
}
