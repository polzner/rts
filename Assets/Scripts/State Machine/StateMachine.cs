using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private Unit _unit;
    private State _currentState;

    public State CurrentState => _currentState;

    public void ChangeState(State newState)
    {
        _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    public void Initialise(State startState)
    {
        _currentState = startState;
        _currentState.Enter();
    }
}
