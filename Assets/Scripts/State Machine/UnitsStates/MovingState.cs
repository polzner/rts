using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : State
{
    private Camera _camera;

    public MovingState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _camera = Camera.main;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Unit.IsSelected && Input.GetMouseButtonDown(1))
        {
            Target = mouse3D.GetCurrentWorldPosition();
            SelectUnits.Instance.SetBoxPosition(Target);
            bool isHitted = Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);

            if (isHitted && hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Unit.SetEnemyTarget(enemy);
                CurrentStateMachine.ChangeState(Unit.AttackingState);
            }
            else if(isHitted && hit.collider.TryGetComponent<ResourceSite>(out ResourceSite site))
            {
                Unit.SetResourceSite(site);
                CurrentStateMachine.ChangeState(Unit.MiningState);
            }
        }
    }
}
