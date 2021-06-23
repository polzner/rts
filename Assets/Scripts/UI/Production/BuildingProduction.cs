using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class BuildingProduction : MonoBehaviour, IPointerClickHandler
{
    private Queue<InProduction> _elementsInPrpgress = new Queue<InProduction>();
    private List<ProductionElement> _possibleProduction;
    private BuildingProfile _prefab;

    public IEnumerable<ProductionElement> PossibleProduction => _possibleProduction;
    public IEnumerable<InProduction> ElementsInProgress => _elementsInPrpgress;

    public event UnityAction OnProductionChange;
    public event UnityAction<InProduction> OnProducrionTimeChanged;
    public event UnityAction<ProductionElement> OnDone;

    public void AddInProduction(ProductionElement element)
    {
        if (_possibleProduction.Contains(element))
        {
            _elementsInPrpgress.Enqueue(new InProduction(element, 0));
        }

        OnProductionChange?.Invoke();
    }

    public void Init(BuildingProfile prefab)
    {
        _prefab = prefab;
        _possibleProduction = prefab.PossibleProduction.Where((x) => true).ToList();
    }

    private void Update()
    {
        if (_elementsInPrpgress.Count == 0) return;
        var element = _elementsInPrpgress.Peek();
        element.IncreaseProductionTime(Time.deltaTime);
        OnProducrionTimeChanged?.Invoke(element);

        if(element.NormilizedProductionTime >= 1)
        {
            _elementsInPrpgress.Dequeue();
            OnProducrionTimeChanged?.Invoke(element);
            OnProductionChange?.Invoke();
            OnDone?.Invoke(element.Element);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ProductionPanel.Instance.DisplayProduction(this,_prefab);
    }

    public class InProduction
    {
        private ProductionElement _element;
        private float _producrionTime;

        public ProductionElement Element => _element;
        public float NormilizedProductionTime => _producrionTime / _element.ConstructTime;

        public void IncreaseProductionTime(float time)
        {
            _producrionTime += time;
        }

        public InProduction(ProductionElement element, float time)
        {
            _element = element;
            _producrionTime = time;
        }
    }

    public void RemoveFromProduction()
    {

    }
}
