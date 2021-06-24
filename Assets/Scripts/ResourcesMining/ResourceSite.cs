using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSite : MonoBehaviour
{
    private int _resourceQuantityInOneIteration;
    private float _timeToMine;

    public void Init(Site site)
    {
        _resourceQuantityInOneIteration = site.ResourceQuantityInOneIteration1;
        _timeToMine = site.TimeToMine;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
