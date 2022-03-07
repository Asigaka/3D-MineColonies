using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Content/Building")]
public class BuildingInfo : ScriptableObject
{
    [SerializeField] string buildingName;
    [SerializeField] string buildingDescription;
    [SerializeField] private Sprite buildingSprite;
    [SerializeField] private Building buildingObject;
    [SerializeField] private BuildingBlueprint buildingBlueprint;

    public string BuildingName { get => buildingName; }
    public string BuildingDescription { get => buildingDescription; }
    public Sprite BuildingSprite { get => buildingSprite; }
    public Building BuildingObject { get => buildingObject; }
    public BuildingBlueprint BuildingBlueprint { get => buildingBlueprint; }
}
