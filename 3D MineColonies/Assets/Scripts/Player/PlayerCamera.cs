using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera rtsCamera;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float smoothFactor = 0.5f;
    [SerializeField] private Plane plane;
    [SerializeField] private bool inRTSMode;
    [SerializeField] private bool rotate;

    private Vector3 velocity;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //rtsCamera = MatchTeams.Instance.PlayerTeam.GameField.RtsCamera;
        playerCamera.transform.rotation = Quaternion.Euler(rotation);
    }

    private void LateUpdate()
    {
        CharacterCamera();

        //if (Input.GetKeyDown(KeyCode.G))
        // SwitchCameraMode();
    }

    public void SwitchCameraMode()
    {
        inRTSMode = !inRTSMode;

        playerCamera.gameObject.SetActive(!inRTSMode);
        rtsCamera.gameObject.SetActive(inRTSMode);
    }

    private void RTSCamera()
    {
        if (Input.touchCount >= 1)
        {
            plane.SetNormalAndPosition(transform.up, transform.position);
        }

        Vector3 delta1 = Vector3.zero;
        Vector3 delta2 = Vector3.zero;

        if (Input.touchCount >= 1)
        {
            delta1 = PlanePositionDelta(Input.GetTouch(0));

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                rtsCamera.transform.Translate(delta1, Space.World);
            }
        }

        if (Input.touchCount >= 2)
        {
            Vector3 pos1 = PlanePosition(Input.GetTouch(0).position);
            Vector3 pos2 = PlanePosition(Input.GetTouch(1).position);
            Vector3 pos1b = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
            Vector3 pos2b = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

            float zoom = Vector3.Distance(pos1, pos2) / Vector3.Distance(pos1b, pos2b);
            if (zoom == 0 || zoom > 10)
                return;

            rtsCamera.transform.position = Vector3.LerpUnclamped(pos1, rtsCamera.transform.position, 1 / zoom);

            if (rotate && pos2b != pos2)
            {
                rtsCamera.transform.RotateAround(pos1, plane.normal,
                   Vector3.SignedAngle(pos2 - pos1, pos2b - pos1b, plane.normal));
            }
        }
    }

    private Vector3 PlanePositionDelta(Touch touch)
    {
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;

        Ray rayBefore = rtsCamera.ScreenPointToRay(touch.position - touch.deltaPosition);
        Ray rayNow = rtsCamera.ScreenPointToRay(touch.position);
        if (plane.Raycast(rayBefore, out float enterBefore) && plane.Raycast(rayNow, out float enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }

    private Vector3 PlanePosition(Vector3 screenPos)
    {
        Ray ray = rtsCamera.ScreenPointToRay(screenPos);
        if (plane.Raycast(ray, out float enter))
        {
            return ray.GetPoint(enter);
        }

        return Vector3.zero;
    }

    private void CharacterCamera()
    {
        Vector3 targetPos = transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(playerCamera.transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
        playerCamera.transform.position = targetPos;
    }
}
