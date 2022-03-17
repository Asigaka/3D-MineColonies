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
    [SerializeField] private List<ItemForSpawn> productItems;
    [SerializeField] private float progressGainMultiplier;

    public string BuildingName { get => buildingName; }
    public string BuildingDescription { get => buildingDescription; }
    public Sprite BuildingSprite { get => buildingSprite; }
    public Building BuildingObject { get => buildingObject; }
    public BuildingBlueprint BuildingBlueprint { get => buildingBlueprint; }
    public List<ItemForSpawn> ProductItems { get => productItems; }
    public float ProgressGainMultiplier { get => progressGainMultiplier; }
}
