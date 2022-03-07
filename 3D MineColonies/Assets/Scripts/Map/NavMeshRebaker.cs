using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class NavMeshRebaker : MonoBehaviour
{
    private NavMeshSurface surface;

    public static NavMeshRebaker Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    public void Rebake()
    {
        surface = GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }
}
