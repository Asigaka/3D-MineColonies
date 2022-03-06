using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    [SerializeField] private List<AInteractive> interactives;
    [SerializeField] private float interactiveRadius = 4;
    [SerializeField] private AInteractive currentInteractive;

    public AInteractive CurrentInteractive { get => currentInteractive; private set => currentInteractive = value; }

    private void Update()
    {
        InteractiveCheck();
    }

    private void InteractiveCheck()
    {
        if (CurrentInteractive != null)
            CurrentInteractive.HideInteractive.Invoke();

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

        if (interactives.Count > 0)
        {
            CurrentInteractive = interactives[0];
            CurrentInteractive.ShowInteractive.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactiveRadius);
    }
}
