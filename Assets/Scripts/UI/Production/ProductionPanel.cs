using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProductionPanel : MonoBehaviour
{
    public static ProductionPanel Instance { get; private set; } 

    [SerializeField] private GameObject _productionElementPrefab;
    [SerializeField] private Transform _possibleProductionElementsContainer;
    [SerializeField] private Transform _inProductionElementsContainer;
    [SerializeField] private TMP_Text Text;
    [SerializeField] private Image Icon;

    private BuildingProduction _current;

    private void Awake()
    {
        Instance = this;
    }

    public void DisplayProduction(BuildingProduction production, BuildingProfile prefab)
    {
        if(_current != null)
        {
            _current.OnProducrionTimeChanged -= DisplayProgressQueue;
            _current.OnProductionChange -= DisplayPossibleProduction;
        }

        Text.text = prefab.Name;
        Icon.sprite = prefab.Sprite;
        _current = production;

        _current.OnProducrionTimeChanged += DisplayProgressQueue;
        _current.OnProductionChange += DisplayPossibleProduction;

        DisplayPossibleProduction();
        DisplayProgressQueue();
    }

    private void DisplayPossibleProduction()
    {
        ClearChild(_possibleProductionElementsContainer);

        foreach (var possible in _current.PossibleProduction)
        {
            var go = Instantiate(_productionElementPrefab, _possibleProductionElementsContainer);
            go.GetComponent<ProductionPresenter>().Present(possible, () => _current.AddInProduction(possible));
        }
    }

    private void DisplayProgressQueue(BuildingProduction.InProduction a=null)
    {
        ClearChild(_inProductionElementsContainer);

        foreach (var inProgress in _current.ElementsInProgress)
        {
            var go = Instantiate(_productionElementPrefab, _inProductionElementsContainer);
            var presenter = go.GetComponent<ProductionPresenter>();
            presenter.Present(inProgress.Element, () => _current.RemoveFromProduction());
            presenter.DisplayProgress(inProgress.NormilizedProductionTime);
        }
    }

    public void ClearChild(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}
