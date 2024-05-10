using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class DynamicNavMesh : MonoBehaviour
{
    private NavMeshSurface surface;

    // Update is called once per frame
    void Update()
    {
        surface.BuildNavMesh();
    }
}
