using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnvironmentPlacer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enviromentPrefabs;
    [SerializeField] private int _objectsQuantity;
    [SerializeField] private NavMeshBuilder _navMeshBuilder;
    [SerializeField] private float _spaceModifier = 1;

    private void Start()
    {
        var camera = Camera.main;

        for (int i = 0; i < _objectsQuantity; i++)
        {
            Physics.Raycast(camera.ScreenPointToRay(new Vector3(Random.Range(0 + camera.pixelWidth - (camera.pixelWidth * _spaceModifier)
                , camera.pixelWidth * _spaceModifier),
                Random.Range(0 + camera.pixelHeight - (camera.pixelHeight * _spaceModifier), camera.pixelHeight * _spaceModifier), 0)), out RaycastHit hit);
            Vector3 position = hit.point;
            Quaternion rotation = Quaternion.AngleAxis(Random.Range(0, 180), Vector3.up);
            Instantiate(_enviromentPrefabs[Random.Range(0, _enviromentPrefabs.Count)], position, rotation);
            
        }

        _navMeshBuilder.Build();
    }
}
