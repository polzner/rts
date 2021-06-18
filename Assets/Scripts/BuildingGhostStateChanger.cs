using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhostStateChanger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _freeState;
    [SerializeField] private List<GameObject> _collisedState;

    public void FreeState()
    {
        _collisedState.ForEach((x) => x.SetActive(false));
        _freeState.ForEach((x) => x.SetActive(true));
    }

    public void CollisedState()
    {
        _collisedState.ForEach((x) => x.SetActive(true));
        _freeState.ForEach((x) => x.SetActive(false));
    }

    public void Placed()
    {
        _collisedState.ForEach((x) => x.SetActive(false));
        _freeState.ForEach((x) => x.SetActive(false));
    }
}
