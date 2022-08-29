using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Target { get; private set; }

    public void Enter(Player target)
    {
        if(enabled == false)
        {
            enabled = true;
            Target = target;
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if(enabled == true)
        {
            enabled = false;
            foreach (var transition in _transitions)
                transition.enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach(var transition in _transitions)
        {
            if (transition.NeedTransit)
               return transition.TargetState;
        }
        return null;
    }
}
