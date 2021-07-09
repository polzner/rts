using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{    
    [SerializeField] private float _radius = 4;
    [SerializeField] private float _strenght = 100;
    [SerializeField] private int _resourceQuantity = 10;
    private float _maxStrenght;

    public float Radius => _radius;
    public Vector3 Position => gameObject.transform.position;
    public int ResourceQuantity => _resourceQuantity;
    public float MaxStrenght => _maxStrenght;

    public event UnityAction<float> OnStrenghtChanged;
    public event UnityAction OnResourceQuantityChanged;
    public event UnityAction OnDestroy;

    private void Awake()
    {
        _maxStrenght = _strenght;
    }

    private void Start()
    {
        OnResourceQuantityChanged?.Invoke();
    }

    public void AddResource(int quantity)
    {
        _resourceQuantity += quantity;
        OnResourceQuantityChanged?.Invoke();
    }

    public void SpendResource(int quantity)
    {
        _resourceQuantity -= quantity;
        OnResourceQuantityChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _strenght -= damage;
        float normalizedValue = _strenght/_maxStrenght;
        OnStrenghtChanged.Invoke(normalizedValue);

        if(_strenght <= 0)
        {
            OnDestroy?.Invoke();
            Destroy(gameObject);
        }
    }
}
