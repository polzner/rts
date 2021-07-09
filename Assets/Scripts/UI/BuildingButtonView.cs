using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonView : MonoBehaviour
{
    [SerializeField] private Button _buttonPrefab;
    [SerializeField] private Transform _buttonsParent;
    [SerializeField] private List<BuildingProfile> _buildings;
    [SerializeField] private Storage _storage;

    private void Start()
    {
        foreach (var item in _buildings)
        {
            var button = Instantiate(_buttonPrefab, _buttonsParent);
            button.GetComponent<BuildingPresenter>().Present(item, _storage);
        }
    }
}
