using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    [SerializeField] private List<Building> buildings;
    [SerializeField] private List<BuildingBlueprint> buildingBlueprints;
    [SerializeField] private LayerMask buildingLayer;

    [SerializeField] private Building selectedBuilding;
    [SerializeField] private BuildingBlueprint selectedBlueprint;
    private PlayerCamera playerCamera;

    public static BuildingsManager Instance;

    public LayerMask BuildingLayer { get => buildingLayer; }
    public Building SelectedBuilding { get => selectedBuilding; }
    public BuildingBlueprint SelectedBlueprint { get => selectedBlueprint; }

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCamera>();
    }

    public void StartBuilding(BuildingBlueprint blueprint)
    {
        buildingBlueprints.Remove(blueprint);
        Building building = Instantiate(blueprint.BuildingInfo.BuildingObject, blueprint.transform.position, blueprint.transform.rotation);
        Destroy(blueprint.gameObject);
        buildings.Add(building);
    }

    public void SpawnBlueprint(BuildingInfo buildingInfo)
    {
        selectedBlueprint = Instantiate(buildingInfo.BuildingBlueprint.gameObject).GetComponent<BuildingBlueprint>();
        buildingBlueprints.Add(selectedBlueprint);
    }

    public void DestroyBlueprint(BuildingBlueprint blueprint)
    {
        buildingBlueprints.Remove(blueprint);
        Destroy(blueprint.gameObject);
    }

    public void SelectBlueprint(BuildingBlueprint blueprint)
    {
        selectedBlueprint = blueprint;
    }

    public void ClearBlueprint(BuildingBlueprint blueprint)
    {
        if (blueprint == selectedBlueprint)
        {
            selectedBlueprint = null;
        }
    }
}
