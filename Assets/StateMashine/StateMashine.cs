using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMashine : MonoBehaviour
{
    [SerializeField] protected State FirstState;

    private State _currentState;

    public State CurrentState => _currentState;

    protected void CheckNextStateReady()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    protected void Reset(State startState)
    {
        _currentState = startState;
        _currentState.Enter();
    }

    protected void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }
}
