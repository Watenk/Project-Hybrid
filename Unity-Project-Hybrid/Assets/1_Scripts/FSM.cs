using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FSM<T>
{
    public BaseState<T> currentState;
    
    private Dictionary<System.Type, BaseState<T>> states = new Dictionary<System.Type, BaseState<T>>(); 

    public FSM(T blackboard, params BaseState<T>[] newStates)
    {
        foreach (BaseState<T> state in newStates)
        {
            state.SetOwner(this, blackboard);
            states.Add(state.GetType(), state);
        }
    }

    public void SwitchState(System.Type newState)
    {
        currentState?.OnExit();
        currentState = states[newState];
        currentState?.OnStart();
    }

    public void OnUpdate()
    {
        currentState?.OnUpdate();
    }
}

public abstract class BaseState<T>
{
    protected FSM<T> fsm;
    protected T blackboard;

    public void SetOwner(FSM<T> fsm, T npc)
    {
        this.fsm = fsm;
        this.blackboard = npc;
    }
    public virtual void OnAwake() {}
    public virtual void OnStart() {}
    public virtual void OnUpdate() {}
    public virtual void OnExit() {}
}
