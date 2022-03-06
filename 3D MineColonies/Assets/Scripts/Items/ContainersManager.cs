using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainersManager : MonoBehaviour
{
    [SerializeField] private Container currentContainer;

    public static ContainersManager Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    public void SetCurrentContainer(Container container)
    {
        currentContainer = container;
    }
}
