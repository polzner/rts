using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingView : MonoBehaviour
{    
    public Transform CurrentTransform;
    private State _currentState = State.InPlacing;
    [SerializeField] private BuildingGhostStateChanger _changer;

    private void Start()
    {
        CurrentTransform = transform;
    }    

    public void Place()
    {
        _changer.Placed();
        _currentState = State.Placed;
    }

    public void StartPlace()
    {
        _currentState = State.InPlacing;
    }

    private enum State
    {
        Placed,
        InPlacing
    }
}
