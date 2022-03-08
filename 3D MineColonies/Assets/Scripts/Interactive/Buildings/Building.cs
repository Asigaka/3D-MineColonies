using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{
    [SerializeField] private BuildingInfo buildingInfo;

    private BuildingsManager manager;
    private bool built;

    public bool Built { get => built; }

    private void Start()
    {
        manager = BuildingsManager.Instance;
    }
}
