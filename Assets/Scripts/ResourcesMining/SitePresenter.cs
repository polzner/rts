using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitePresenter : MonoBehaviour
{
    [SerializeField] private List<Site> _sites = new List<Site>();
    [SerializeField] private int _sitesQuantity;
    [SerializeField] private GameObject _prefab;


    private void Start()
    {
        for (int i = 0; i < _sitesQuantity; i++)
        {
            Vector3 position = new Vector3(0,0,0);

            /*
            нужно рандомить место для 
            ресурсов                           
            */

            var site = Instantiate(_prefab, position, Quaternion.identity);
        }
    }
}
