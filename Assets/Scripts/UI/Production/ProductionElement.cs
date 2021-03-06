using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProductionElement", order = 9997)]
public class ProductionElement : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _time;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _price;

    public GameObject Prefab => _prefab;
    public Sprite Sprite => _sprite;
    public float ConstructTime => _time;
    public int Price => _price;
}
