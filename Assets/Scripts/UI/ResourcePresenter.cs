using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcePresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resourceQuantityText;

    private void Awake()
    {
        _resourceQuantityText.text = "0";
    }

    private void OnEnable()
    {
        ResourceManager.Instance.OnResourceQuantityChanged += ResourceQuantityChangedHandler;
    }

    private void OnDisable()
    {
        ResourceManager.Instance.OnResourceQuantityChanged -= ResourceQuantityChangedHandler;
    }

    private void ResourceQuantityChangedHandler()
    {
        _resourceQuantityText.text = ResourceManager.Instance.ResourceQuantity.ToString();
    }
}
