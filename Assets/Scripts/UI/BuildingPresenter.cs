using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class BuildingPresenter : MonoBehaviour
{
    [SerializeField] private Text _buildingName;
    [SerializeField] private Image _buildingImage;
    [SerializeField] private Text _buildingPrice;
    [SerializeField] private Button _button;

    public void Present(BuildingProfile building)
    {
        _buildingName.text = building.Name;
        _buildingImage.sprite = building.Sprite;

        if (building != null)
            _button.onClick.AddListener(() => BuildingPlaceLogick.Instance.Place(building));
    }

    
}
