using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Character Character;
    protected StateMachine CurrentStateMachine;
    protected Vector3 Target;
    public string Name { protected set; get; }

    public State(Character unit, StateMachine stateMachine)
    {
        Character = unit;
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
