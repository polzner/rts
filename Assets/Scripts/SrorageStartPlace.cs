using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrorageStartPlace : MonoBehaviour
{
    [SerializeField] private GameObject _storage;
    [SerializeField] private CollisionTrigger _trigger;
    [SerializeField] private BuildingGhostStateChanger _changer;
    [SerializeField] private GameObject _enemyPlacer;

    private void Start()
    {
        _storage.layer = LayerMask.NameToLayer("Ghost");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && TryPlace())
        {
            SelectUnits.Instance.SetStorage(_storage.GetComponent<Storage>());

            Destroy(this);
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        _storage.transform.position = mouse3D.GetCurrentWorldPosition();
    }

    private bool TryPlace()
    {
        if(_trigger.IsCollised)
        {
            return false;
        }
        else
        {
            _storage.layer = LayerMask.NameToLayer("MiningSite");
            Destroy(_trigger);
            _changer.Placed();
            _enemyPlacer.SetActive(true);
            return true;
        }
    }
}
