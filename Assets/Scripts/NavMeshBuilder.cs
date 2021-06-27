using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class NavMeshBuilder : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navMeshSurface;

    public void Build()
    {
        _navMeshSurface.BuildNavMesh();
    }
}
