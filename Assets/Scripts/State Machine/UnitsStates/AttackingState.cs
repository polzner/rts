using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackingState : State
{
    private Camera _camera;
    private Enemy _enemy;
    private float _attackTimer;
    [SerializeField] private float _attackTimerMax = 1;
    [SerializeField] private float _attackDistance = 3;

    public AttackingState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy = Unit.EnemyTarget;
        _enemy.Selected(true);
        SelectUnits.Instance.SetCirclePosition(_enemy.Position, _attackDistance);
        _camera = Camera.main;
    }

    public override void Exit()
    {
        base.Exit();
        if(_enemy != null)
        {
            _enemy.Selected(false);
            Unit.SetDestination(mouse3D.GetCurrentWorldPosition());
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_enemy != null && (Unit.Position - _enemy.Position).magnitude <= _attackDistance + 0.5f)
        {
            _attackTimer -= Time.deltaTime;
            if (_attackTimer <= 0)
            {
                _attackTimer = _attackTimerMax;
                _enemy.TakeDamage(Unit.Damage);
            }
        }

        if(Unit.IsSelected && Input.GetMouseButtonDown(1) && 
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit) &&
            hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _enemy.Selected(false);
            _enemy = enemy;
            _enemy.Selected(true);
            SelectUnits.Instance.SetCirclePosition(_enemy.Position, _attackDistance);
        }
        else if (Input.GetMouseButtonDown(1) && Unit.IsSelected || _enemy == null)
        {
            Unit.StateMachine.ChangeState(Unit.GroundedState);
        }
    }
}
