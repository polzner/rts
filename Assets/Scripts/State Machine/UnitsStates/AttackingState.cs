using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackingState : State
{
    private Camera _camera;
    private Enemy _enemy;
    private Unit _unit;
    private float _attackTimer;

    public AttackingState(Character unit, StateMachine stateMachine) : base(unit, stateMachine)
    {
        Name = "Attacking";
    }

    public override void Enter()
    {
        base.Enter();
        _unit = (Unit)Character;
        _enemy = _unit.EnemyTarget;
        _enemy.Selected(true);
        _camera = Camera.main;       
        _enemy.OnPositionChange += SetPosition;
    }

    public override void Exit()
    {
        base.Exit();
        if(_enemy != null)
        {
            _enemy.OnPositionChange -= SetPosition;
            _enemy.Selected(false);
            _unit.SetDestination(mouse3D.GetCurrentWorldPosition());
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_enemy != null && (_unit.Position - _enemy.Position).magnitude <= _unit.AttackDistance + 0.5f)
        {
            _attackTimer -= Time.deltaTime;
            if (_attackTimer <= 0)
            {
                _attackTimer = _unit.AttackTimerMax;
                _enemy.TakeDamage((int)_unit.Damage);
            }
        }

        if(_unit.IsSelected && Input.GetMouseButtonDown(1) && 
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit) &&
            hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _enemy.OnPositionChange -= SetPosition;
            _enemy.Selected(false);
            _enemy = enemy;
            _enemy.Selected(true);
            _enemy.OnPositionChange += SetPosition;
        }
        else if (Input.GetMouseButtonDown(1) && _unit.IsSelected || _enemy == null)
        {
            _unit.StateMachine.ChangeState(_unit.GroundedState);
        }
    }

    private void SetPosition()
    {
        SelectUnits.Instance.SetCirclePosition(_enemy.Position, _unit.AttackDistance);
    }
}
