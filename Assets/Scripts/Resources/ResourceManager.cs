using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    
    private int _resourceQuantity;

    public int ResourceQuantity => _resourceQuantity;

    public event UnityAction OnResourceQuantityChanged;

    private void Awake()
    {
        Instance = this;
        _resourceQuantity = 0;
    }

    public void AddResource(int quantity)
    {
        _resourceQuantity += quantity;
        OnResourceQuantityChanged?.Invoke();
    }
}
