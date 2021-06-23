using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlaceLogick : MonoBehaviour
{
    public static BuildingPlaceLogick Instance { get; private set; }
    private PlacingBuilding _currentBuilding;

    public void Place(BuildingProfile building)
    {
        if (_currentBuilding != null)
            return;

        GameObject ghost = Instantiate(building.BuildingPrefab);
        ghost.layer = LayerMask.NameToLayer("Ghost");
        _currentBuilding = new PlacingBuilding(ghost.GetComponent<BuildingView>(),
                                               ghost.GetComponent<CollisionTrigger>(),
                                               ghost.GetComponent<BuildingProduction>(),
                                               ghost, building);

    }

    public void Update()
    {
        if (_currentBuilding != null)
        {

            if (Input.GetMouseButtonDown(0) && _currentBuilding.TryPlace())
            {
                _currentBuilding = null;
            }
            else
            {
                _currentBuilding.Move(mouse3D.GetCurrentWorldPosition()); 
            }            
        }
    }

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public class PlacingBuilding
    {
        private BuildingView _view;
        private CollisionTrigger _trigger;
        private bool _isPlaced = false;
        private BuildingProduction _production;
        private BuildingProfile _prefab;
        private GameObject _ghost;

        public BuildingView View => _view;
        public CollisionTrigger Trigger => _trigger;

        public PlacingBuilding(BuildingView view, CollisionTrigger trigger, BuildingProduction production, GameObject ghost, BuildingProfile prefab)
        {
            _prefab = prefab;
            _view = view;
            _trigger = trigger;
            _production = production;
            _ghost = ghost;
        }

        public void Move(Vector3 point)
        {
            _view.CurrentTransform.position = point;
        }

        public bool TryPlace()
        {
            if (_isPlaced)
                return false;

            if (_trigger.IsCollised)
                return false;
            _ghost.layer = LayerMask.NameToLayer("Buildings");
            Destroy(_trigger);
            _view.Place();
            _production.Init(_prefab);
            _isPlaced = true;
            return true;
        }
    }
}
