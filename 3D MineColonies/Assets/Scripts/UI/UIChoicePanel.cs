using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChoicePanel : MonoBehaviour
{
    [SerializeField] private Button agreeBtn;
    [SerializeField] private Button disagreeBtn;

    public Button AgreeBtn { get => agreeBtn; }
    public Button DisagreeBtn { get => disagreeBtn; }

    private void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
