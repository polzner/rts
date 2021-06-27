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
    private int _resourceQuantity;

    public float Radius => _radius;
    public Vector3 Position => gameObject.transform.position;
    public int ResourceQuantity => _resourceQuantity;

    public event UnityAction OnResourceQuantityChanged;

    private void Awake()
    {
        _resourceQuantity = 0;
    }

    public void AddResource(int quantity)
    {
        _resourceQuantity += quantity;
        OnResourceQuantityChanged?.Invoke();
    }
}
