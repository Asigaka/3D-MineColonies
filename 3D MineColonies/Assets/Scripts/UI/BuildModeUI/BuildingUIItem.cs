using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingUIItem : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image buildingImage;

    [SerializeField] private BuildingInfo buildingInfo;

    public void OnPointerDown(PointerEventData eventData)
    {
        BuildingsManager.Instance.SpawnBlueprint(buildingInfo);
    }

    public void SetInfo(BuildingInfo buildingInfo)
    {
        //this.buildingInfo = buildingInfo;
        //buildingImage.sprite = buildingInfo.BuildingSprite;
    }
}
