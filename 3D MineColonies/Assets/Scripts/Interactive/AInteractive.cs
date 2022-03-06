using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class AInteractive : MonoBehaviour
{
    [HideInInspector] public UnityEvent ShowInteractive;
    [HideInInspector] public UnityEvent HideInteractive;

    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 7;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.black;
        ShowInteractive.AddListener(TurnOnInteractive);
        HideInteractive.AddListener(TurnOffInteractive);
        HideInteractive.Invoke();
    }

    private void TurnOnInteractive()
    {
        outline.enabled = true;
        UIPlayerInteractives.Instance.InteractiveBtnActive(true);
    }

    private void TurnOffInteractive()
    {
        outline.enabled = false;
        UIPlayerInteractives.Instance.InteractiveBtnActive(false);
    }

    public virtual void Interactive()
    {
        Debug.Log(gameObject.name + " interactive");
    }
}
