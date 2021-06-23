using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Building", order = 9999)]
public class BuildingProfile : ScriptableObject
{
    [SerializeField] private GameObject _buildingPrefab;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _price;

    public string Name => _name;
    public Sprite Sprite => _sprite;
    public float Price => _price;
    public GameObject BuildingPrefab => _buildingPrefab;

    public List<ProductionElement> PossibleProduction;
}
