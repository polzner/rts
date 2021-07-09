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

    public void Present(BuildingProfile building, Storage storage)
    {
        _buildingName.text = building.Name;
        _buildingName.text += $"\n{ building.Price.ToString()}";
        _buildingImage.sprite = building.Sprite;

        if (building != null)
            _button.onClick.AddListener(() =>
            {
                if(storage.ResourceQuantity >= building.Price)
                {
                    BuildingPlaceLogick.Instance.Place(building);
                    storage.SpendResource(building.Price);
                }
            });
    }


}
