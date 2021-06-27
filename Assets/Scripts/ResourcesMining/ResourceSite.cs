using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceSite : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private int _resourceQuantityInOneIteration;
    private float _timeToMine;
    private float _distanceToStartMining;

    public int ResourceQuantityInOneIteration => _resourceQuantityInOneIteration;
    public float MaxMiningTime => _timeToMine;
    public float DistanceToStartMining => _distanceToStartMining;

    public void Init(Site site)
    {
        _resourceQuantityInOneIteration = site.ResourceQuantityInOneIteration;
        _timeToMine = site.TimeToMine;
        _distanceToStartMining = site.DistanceToStartMining;
        _text.text = site.Name;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
