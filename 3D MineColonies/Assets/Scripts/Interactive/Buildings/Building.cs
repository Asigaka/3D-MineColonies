using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private BuildingInfo buildingInfo;

    private BuildingsManager manager;
    private bool built;

    public bool Built { get => built; }

    private void Start()
    {
        manager = BuildingsManager.Instance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        manager.SelectConstructedBuilding(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
