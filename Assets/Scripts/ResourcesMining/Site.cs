using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Site", order = 9999)]
public class Site : ScriptableObject
{
    [SerializeField] private int _resourceQuantityInOneIteration;
    [SerializeField] private float _timeToMine;
    [SerializeField] private float _distanceToStartMining;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private string _name;

    public int ResourceQuantityInOneIteration => _resourceQuantityInOneIteration;
    public float TimeToMine => _timeToMine;
    public float DistanceToStartMining => _distanceToStartMining;
    public GameObject Prefab => _prefab;
    public string Name => _name;
}
