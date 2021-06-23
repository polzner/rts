using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProductionPresenter : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    public void Present(ProductionElement element, UnityAction onClick)
    {
        _icon.sprite = element.Sprite;
        _image.fillAmount = 0;
        _button.onClick.AddListener(onClick);
    }

    public void DisplayProgress(float progress)
    {
        _image.fillAmount = progress;
    }
}
