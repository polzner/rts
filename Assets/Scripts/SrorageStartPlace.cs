using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrorageStartPlace : MonoBehaviour
{
    [SerializeField] private GameObject _storage;
    [SerializeField] private CollisionTrigger _trigger;
    [SerializeField] private BuildingGhostStateChanger _changer;

    private void Start()
    {
        _storage.layer = LayerMask.NameToLayer("Ghost");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && TryPlace())
        {
            _storage = null;
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
            _storage.layer = LayerMask.NameToLayer("Buildings");
            Destroy(_trigger);
            _changer.Placed();
            return true;
        }
    }
}
