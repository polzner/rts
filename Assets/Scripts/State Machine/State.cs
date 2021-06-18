using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Unit Unit;
    protected StateMachine CurrentStateMachine;
    protected Vector3 Target;

    public State(Unit unit, StateMachine stateMachine)
    {
        Unit = unit;
        CurrentStateMachine = stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void InputUpdate()
    {

    }
}
