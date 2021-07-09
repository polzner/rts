using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningState : State
{
    private Camera _camera;
    private ResourceSite _site;
    private float _miningTimer;
    private Storage _storage;
    private int _resourceQuantity;
    private Vector3 _miningUnitPosition;
    private _state state = _state.Mining;
    private Unit _unit;

    private enum _state
    {
        Mining,
        Delivering
    }

    public MiningState(Character unit, StateMachine stateMachine) : base(unit, stateMachine)
    {
        Name = "Mining";
    }

    public override void Enter()
    {
        base.Enter();
        _unit = (Unit)Character;
        _site = ((Unit)Character).ResourceSite;
        _storage = SelectUnits.Instance.Storage;
        SelectUnits.Instance.SetRandomCirclePosition(_site.GetPosition(), _site.DistanceToStartMining);
        _camera = Camera.main;
    }

    public override void Exit()
    {
        base.Exit();
        _unit.SetDestination(mouse3D.GetCurrentWorldPosition());
    }

    public override void LogicUpdate()
    {
        if((_unit.Position - _site.GetPosition()).magnitude <= _site.DistanceToStartMining + 1f && state == _state.Mining)
        {
            _miningUnitPosition = _unit.Position;
            _miningTimer += Time.deltaTime;
            if(_miningTimer >= _site.MaxMiningTime)
            {
                _resourceQuantity = _site.ResourceQuantityInOneIteration;
                _unit.SetDestination(_storage.Position);
                _miningTimer = 0;
                state = _state.Delivering;
            }
        }    
        
        if(_storage != null && (_unit.Position - _storage.Position).magnitude <= _storage.Radius && state == _state.Delivering)
        {
            _storage.AddResource(_site.ResourceQuantityInOneIteration);
            _resourceQuantity = 0;
            _unit.SetDestination(_miningUnitPosition);
            state = _state.Mining;
        }

        if (Input.GetMouseButtonDown(1) && _unit.IsSelected && Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit) &&
            hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _unit.SetEnemyTarget(enemy);
            CurrentStateMachine.ChangeState((State)_unit.AttackingState);
        }
        else if(Input.GetMouseButtonDown(1) && _unit.IsSelected)
        {
            _unit.StateMachine.ChangeState(_unit.GroundedState);
        }
    }
}
