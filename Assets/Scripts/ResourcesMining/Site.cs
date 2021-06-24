using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Site", order = 9999)]
public class Site : ScriptableObject
{
    [SerializeField] private int _resourceQuantityInOneIteration;
    [SerializeField] private float _timeToMine;

    public int ResourceQuantityInOneIteration1 => _resourceQuantityInOneIteration;
    public float TimeToMine => _timeToMine;
}
