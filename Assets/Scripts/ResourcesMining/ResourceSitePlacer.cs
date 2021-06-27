using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSitePlacer : MonoBehaviour
{
    [SerializeField] private List<Site> _sites = new List<Site>();
    [SerializeField] private int _sitesQuantity;
    [SerializeField] private float _spaceModifier = 1;


    private void Start()
    {
        var camera = Camera.main;

        for (int i = 0; i < _sitesQuantity; i++)
        {
            Physics.Raycast(camera.ScreenPointToRay(new Vector3(Random.Range(0 + camera.pixelWidth - (camera.pixelWidth * _spaceModifier)
                , camera.pixelWidth * _spaceModifier),
                Random.Range(0 + camera.pixelHeight - (camera.pixelHeight * _spaceModifier), camera.pixelHeight * _spaceModifier), 0)), out RaycastHit hit);
            Vector3 position = hit.point;

            var currentSite = _sites[Random.Range(0, _sites.Count)];
            var site = Instantiate(currentSite.Prefab, position, Quaternion.identity);            
            site.GetComponent<ResourceSite>().Init(currentSite);
        }
    }
}
