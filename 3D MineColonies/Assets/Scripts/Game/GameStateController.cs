using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState { ActionMode, BuildMode, Map}
public class GameStateController : MonoBehaviour
{
    public UnityEvent onGameStateChange;
    private PlayerCamera playerCamera;
    [SerializeField] private GameState currentState;

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

        currentState = state;
        onGameStateChange.Invoke();
    }
}
