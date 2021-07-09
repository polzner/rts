using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State _currentState;

    public event Action<string> OnStateChanged;
    public State CurrentState => _currentState;

    public void ChangeState(State newState)
    {
        _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
        OnStateChanged?.Invoke(_currentState.Name);
    }

    public void Initialise(State startState)
    {
        _currentState = startState;
        _currentState.Enter();
        OnStateChanged?.Invoke(_currentState.Name);
    }
}
