using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : State
{
    private Camera _camera;
    private Unit _unit;

    public MovingState(Character unit, StateMachine stateMachine) : base(unit, stateMachine)
    {
        Name = "Moving";
    }

    public override void Enter()
    {
        base.Enter();
        _unit = (Unit)Character;
        _camera = Camera.main;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_unit.IsSelected && Input.GetMouseButtonDown(1))
        {
            Target = mouse3D.GetCurrentWorldPosition();
            SelectUnits.Instance.SetBoxPosition(Target);
            bool isHitted = Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);

            if (isHitted && hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _unit.SetEnemyTarget(enemy);
                CurrentStateMachine.ChangeState((State)_unit.AttackingState);
            }
            else if(isHitted && hit.collider.TryGetComponent<ResourceSite>(out ResourceSite site))
            {
                _unit.SetResourceSite(site);
                CurrentStateMachine.ChangeState((State)_unit.MiningState);
            }
        }
    }
}
