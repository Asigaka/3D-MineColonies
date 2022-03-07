using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { ActionMode, BuildMode, Map}
public class GameStateController : MonoBehaviour
{
    private PlayerCamera playerCamera;
    private GameState currentState;

    public static GameStateController Instance;

    public GameState CurrentState { get => currentState; }

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;

        playerCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCamera>();
    }

    public void ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.ActionMode:
                Time.timeScale = 1;
                playerCamera.SwitchCameraMode();
                break;
            case GameState.BuildMode:
                Time.timeScale = 0.5f;
                playerCamera.SwitchCameraMode();
                break;
            case GameState.Map:
                break;
        }
    }
}
