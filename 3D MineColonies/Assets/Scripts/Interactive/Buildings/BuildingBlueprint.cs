using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingBlueprint : MonoBehaviour
{
    [SerializeField] private UIChoicePanel choicePanel;
    [SerializeField] private float bluePrintRaduis = 3;
    [SerializeField] private BuildingInfo buildingInfo;

    private PlayerCamera playerCamera;
    private BuildingsManager buildingsManager;
    private GameStateController gameState;
    private Vector3 lastCorrectPos;

    public BuildingInfo BuildingInfo { get => buildingInfo; }

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCamera>();
        buildingsManager = BuildingsManager.Instance;
        gameState = GameStateController.Instance;

        choicePanel.AgreeBtn.onClick.AddListener(AgreeBlueprint);
        choicePanel.DisagreeBtn.onClick.AddListener(DisagreeBlueprint);

        if (playerCamera.GetTouchPosition() != Vector3.zero)
        {
            //transform.position = playerCamera.GetTouchPosition();
        }

        choicePanel.gameObject.SetActive(gameState.CurrentState == GameState.BuildMode);
        gameState.onGameStateChange.AddListener(OnGameStateChange);
    }

    private bool CheckCollidersAround()
    {
        Collider[] collidersArray = Physics.OverlapSphere(transform.position, bluePrintRaduis, buildingsManager.BuildingLayer);
        List<Collider> collidersAround = collidersArray.ToList();

        for (int i = 0; i < collidersAround.Count; i++)
        {
            if (collidersAround[i].transform == transform)
            {
                collidersAround.Remove(collidersAround[i]);
            }
        }

        if (collidersAround.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void AgreeBlueprint()
    {
        if (gameState.CurrentState == GameState.BuildMode)
        {
            buildingsManager.StartBuilding(this);
        }
    }

    private void DisagreeBlueprint()
    {
        if (gameState.CurrentState == GameState.BuildMode)
        {
            buildingsManager.DestroyBlueprint(this);
        }
    }

    private void OnMouseDown()
    {
        if (gameState.CurrentState == GameState.BuildMode)
        {
            choicePanel.gameObject.SetActive(true);
            buildingsManager.SelectBlueprint(this);
        }
    }

    private void OnMouseDrag()
    {
        if (gameState.CurrentState == GameState.BuildMode)
        {
            choicePanel.gameObject.SetActive(false);

            if (CheckCollidersAround())
            {
                lastCorrectPos = transform.position;
            }

            if (playerCamera.GetTouchPosition() != Vector3.zero)
            {
                transform.position = playerCamera.GetTouchPosition();
            }
        }
    }

    private void OnMouseUp()
    {
        if (gameState.CurrentState == GameState.BuildMode)
        {
            transform.position = lastCorrectPos;
            choicePanel.gameObject.SetActive(true);
        }

        buildingsManager.ClearBlueprint(this);
    }

    private void OnDrawGizmos()
    {
        if (gameState && gameState.CurrentState == GameState.BuildMode)
        {
            if (CheckCollidersAround())
                Gizmos.color = Color.green;
            else
                Gizmos.color = Color.red;
        }

        Gizmos.DrawWireSphere(transform.position, bluePrintRaduis);
    }

    private void OnBecameInvisible()
    {
        choicePanel.gameObject.SetActive(false);
        buildingsManager.ClearBlueprint(this);
    }

    private void OnGameStateChange()
    {
        //choicePanel.gameObject.SetActive(gameState.CurrentState == GameState.BuildMode);
        gameObject.SetActive(gameState.CurrentState == GameState.BuildMode);
    }
}
