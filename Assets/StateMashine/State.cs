using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _Transitions;

    public void Enter()
    {
        if(enabled == false)
        {
            enabled = true;

            foreach(var transition in _Transitions)
            {
                transition.enabled = true;
                transition.Initialized();
            }
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _Transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    public void Exit()
    {
        if(enabled == true)
        {
            foreach (var transition in _Transitions)
                transition.enabled = false;

            enabled = false;
        }
    }
}
