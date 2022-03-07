using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingBlueprint : MonoBehaviour
{
    private PlayerCamera playerCamera;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCamera>();

        if (playerCamera.GetTouchPosition() != Vector3.zero)
        {
            transform.position = playerCamera.GetTouchPosition();
        }
    }

    private void OnMouseDown()
    {
    }

    private void OnMouseUp()
    {
    }

    private void OnMouseDrag()
    {
        if (playerCamera.GetTouchPosition() != Vector3.zero)
        {
            transform.position = playerCamera.GetTouchPosition();
        }
    }
}
