using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMap : MonoBehaviour
{
    [SerializeField] private GameObject planeObject;
    [SerializeField] private PerlinNoise perlinNoise;
    [SerializeField] private List<MapObject> mapObjects;

    private void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        perlinNoise.GenerateGround();

        foreach (MapObject mapObject in mapObjects)
        {
            int amount = Random.Range(mapObject.MinAmount, mapObject.MaxAmount);

            for (int i = 0; i < amount; i++)
            {
                Vector3 objPos = new Vector3(Random.Range(GetMinPlaneScale(), GetMaxPlaneScale()), 
                    0, Random.Range(GetMinPlaneScale(), GetMaxPlaneScale()));

                GameObject newObject = Instantiate(mapObject.SpawnObject);
                newObject.transform.position = objPos;
                newObject.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                newObject.transform.SetParent(planeObject.transform);
            }
        }

        NavMeshRebaker.Instance.Rebake();
    }

    private float GetMinPlaneScale()
    {
        return planeObject.transform.localScale.x * -5;
    }

    private float GetMaxPlaneScale()
    {
        return planeObject.transform.localScale.x * 5;
    }
}
