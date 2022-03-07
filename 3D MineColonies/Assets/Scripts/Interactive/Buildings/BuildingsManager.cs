using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    [SerializeField] private List<Building> buildings;

    [SerializeField] private Building selectedConstructedBuilding;
    [SerializeField] private BuildingBlueprint selectedBlueprintBuilding;
    private PlayerCamera playerCamera;

    public static BuildingsManager Instance;

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

    private void Update()
    {
        if (selectedBlueprintBuilding)
        {
            
        }
    }

    public void SpawnBlueprint(BuildingInfo buildingInfo)
    {
        if (selectedBlueprintBuilding)
            Destroy(selectedBlueprintBuilding.gameObject);

        selectedBlueprintBuilding = Instantiate(buildingInfo.BuildingBlueprint.gameObject).GetComponent<BuildingBlueprint>();
    }

    public void SelectConstructedBuilding(Building building)
    {
        selectedConstructedBuilding = Instantiate(building.gameObject).GetComponent<Building>();
    }
}
