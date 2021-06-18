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
        _currentBuilding = new PlacingBuilding(ghost.GetComponent<BuildingView>(), ghost.GetComponent <CollisionTrigger>());
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
        private BuildingView _prefab;
        private CollisionTrigger _trigger;
        private bool _isPlaced = false;

        public BuildingView Prefab => _prefab;
        public CollisionTrigger Trigger => _trigger;

        public PlacingBuilding(BuildingView view, CollisionTrigger trigger)
        {
            _prefab = view;
            _trigger = trigger;
        }

        public void Move(Vector3 point)
        {
            _prefab.CurrentTransform.position = point;
        }

        public bool TryPlace()
        {
            if (_isPlaced)
                return false;

            if (_trigger.IsCollised)
                return false;

            Destroy(_trigger);
            _prefab.Place();
            _isPlaced = true;
            return true;
        }
    }
}
