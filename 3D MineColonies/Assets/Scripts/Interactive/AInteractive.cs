using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class AInteractive : MonoBehaviour
{
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 7;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.black;

        HideInteractive();
    }

    public void ShowInteractive()
    {
        outline.enabled = true;
        UIPlayerInteractives.Instance.InteractiveBtnActive(true);
    }

    public void HideInteractive()
    {
        outline.enabled = false;
        UIPlayerInteractives.Instance.InteractiveBtnActive(false);
    }

    public virtual void Interactive()
    {

    }
}
