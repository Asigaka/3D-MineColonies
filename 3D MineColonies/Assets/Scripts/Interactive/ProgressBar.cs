using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider barSlider;

    private void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }

    public void ChangeValue(float value)
    {
        barSlider.value = value;
    }

    public void ChangeMaxValue(float maxValue)
    {
        barSlider.maxValue = maxValue;
    }
}
