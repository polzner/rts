using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceQuantityPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _resourceQuantityText;
    [SerializeField] private Storage _storage;

    private void Awake()
    {
        _resourceQuantityText.text = "0";
    }

    private void OnEnable()
    {
        _storage.OnResourceQuantityChanged += ResourceQuantityChangedHandler;
    }

    private void OnDisable()
    {
        _storage.OnResourceQuantityChanged -= ResourceQuantityChangedHandler;
    }

    private void ResourceQuantityChangedHandler()
    {
        _resourceQuantityText.text = _storage.ResourceQuantity.ToString();
    }
}
