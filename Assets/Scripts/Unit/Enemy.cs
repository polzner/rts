using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _selectedIconGameObject;

    private int _health = 100;
    private int _maxHealth = 100;
    private bool _isSelected;
    private Transform _selfTransform;

    public int MaxHealth => _maxHealth;
    public Vector3 Position => _selfTransform.position;

    public event UnityAction<int,int> HealthChanged;

    private void Awake()
    {
        Selected(false);
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health,_maxHealth);
        _selfTransform = GetComponent<Transform>();
    }

    public void Selected(bool isSelected)
    {
        _isSelected = isSelected;
        _selectedIconGameObject.SetActive(isSelected);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health,_maxHealth);
    }

}
