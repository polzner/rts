using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProductionBuilding : MonoBehaviour
{
    private Queue<InProduction> _elementsInPrpgress;
    private List<ProductionElement> _possibleProduction;

    public event UnityAction OnProductionChange;
    public event UnityAction<>

    public void AddInProduction(ProductionElement element)
    {
        _elementsInPrpgress.Enqueue(element);
    }

    public class InProduction
    {
        public ProductionElement Element;
        public float ProductionTime;

        public void
    }
}
