using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _selectedIconGameObject;

    [SerializeField] private int _health = 100;
    private int _maxHealth;
    private bool _isSelected;
    private Transform _selfTransform;

    public int MaxHealth => _maxHealth;
    public Vector3 Position => _selfTransform.position;

    public event UnityAction<int> HealthChanged;

    private void Awake()
    {
        Selected(false);
    }

    private void Start()
    {
        _maxHealth = _health;
        HealthChanged?.Invoke(_maxHealth);
        _selfTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if(_health <= 0)
        {
            Die();
        }
    }

    public void Selected(bool isSelected)
    {
        _isSelected = isSelected;
        _selectedIconGameObject.SetActive(isSelected);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(_health);
        _health -= damage;
        HealthChanged?.Invoke(_health);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
