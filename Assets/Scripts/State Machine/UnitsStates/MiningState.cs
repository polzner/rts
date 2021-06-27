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

    private enum _state
    {
        Mining,
        Delivering
    }

    public MiningState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _site = Unit.ResourceSite;
        _storage = SelectUnits.Instance.Storage;
        SelectUnits.Instance.SetCirclePosition(_site.GetPosition(), _site.DistanceToStartMining);
        _camera = Camera.main;
    }

    public override void Exit()
    {
        base.Exit();
        Unit.SetDestination(mouse3D.GetCurrentWorldPosition());
    }

    public override void LogicUpdate()
    {
        if((Unit.Position - _site.GetPosition()).magnitude <= _site.DistanceToStartMining + 0.5f && state == _state.Mining)
        {
            _miningUnitPosition = Unit.Position;
            _miningTimer += Time.deltaTime;
            if(_miningTimer >= _site.MaxMiningTime)
            {
                _resourceQuantity = _site.ResourceQuantityInOneIteration;
                Unit.SetDestination(_storage.Position);
                _miningTimer = 0;
                state = _state.Delivering;
            }
        }    
        
        if((Unit.Position - _storage.Position).magnitude <= _storage.Radius && state == _state.Delivering)
        {
            _storage.AddResource(_site.ResourceQuantityInOneIteration);
            _resourceQuantity = 0;
            Unit.SetDestination(_miningUnitPosition);
            state = _state.Mining;
        }

        if (Input.GetMouseButtonDown(1) && Unit.IsSelected && Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit) &&
            hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Unit.SetEnemyTarget(enemy);
            CurrentStateMachine.ChangeState(Unit.AttackingState);
        }
        else if(Input.GetMouseButtonDown(1) && Unit.IsSelected)
        {
            Unit.StateMachine.ChangeState(Unit.GroundedState);
        }
    }
}
