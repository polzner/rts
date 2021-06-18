using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackingState : State
{
    private Enemy _enemy;
    private float _attackTimer;
    private float _attackTimerMax = 1;
    private float _attackDistance = 1;

    public AttackingState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy = Unit.EnemyTarget;
        SelectUnits.Instance.SetCirclePosition(_enemy.Position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InputUpdate()
    {
        base.InputUpdate();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if ((Unit.Position - _enemy.Position).magnitude <= _attackDistance)
        {
            _attackTimer -= Time.deltaTime;
            if (_attackTimer <= 0)
            {
                _attackTimer = _attackTimerMax;
                _enemy.TakeDamage(Unit.Damage);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Unit.StateMachine.ChangeState(Unit.GroundedState);
        }
    }
}
