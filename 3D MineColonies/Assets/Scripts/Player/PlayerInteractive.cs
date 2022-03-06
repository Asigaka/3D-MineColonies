using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInteractive : MonoBehaviour
{
    [SerializeField] private List<AInteractive> interactives;
    [SerializeField] private float interactiveRadius = 4;
    [SerializeField] private AInteractive currentInteractive;

    private PlayerMovement movement;

    public AInteractive CurrentInteractive { get => currentInteractive; private set => currentInteractive = value; }

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        InteractiveCheck();
    }

    private void InteractiveCheck()
    {
        if (CurrentInteractive != null)
            CurrentInteractive.HideInteractive();

        CurrentInteractive = null;
        interactives.Clear();
        Collider[] checkColliders = Physics.OverlapSphere(transform.position, interactiveRadius);

        foreach (Collider collider in checkColliders)
        {
            AInteractive interactive = collider.GetComponent<AInteractive>();

            if (interactive)
            {
                interactives.Add(interactive);
            }
        }

        if (interactives.Count > 1)
        {
            interactives.Sort(delegate (AInteractive t1, AInteractive t2)
            {
                return Vector3.Distance(t1.transform.position, transform.position).CompareTo(Vector3.Distance(t2.transform.position, transform.position));
            });
        }
        
        if (interactives.Count > 0)
        {
            CurrentInteractive = interactives[0];
            CurrentInteractive.ShowInteractive();
        }
    }

    public void OnInteractiveClick()
    {
        if (CurrentInteractive != null)
        {
            CurrentInteractive.Interactive();
            movement.RotateToTarget(CurrentInteractive.transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactiveRadius);
    }
}
