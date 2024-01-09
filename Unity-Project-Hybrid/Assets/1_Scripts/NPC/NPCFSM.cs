using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCFSM
{
    public BaseState currentState;
    
    private Dictionary<System.Type, BaseState> states = new Dictionary<System.Type, BaseState>(); 

    public NPCFSM(NPC npc, params BaseState[] newStates)
    {
        foreach (BaseState state in newStates)
        {
            state.SetOwner(this, npc);
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

public abstract class BaseState
{
    protected NPCFSM fsm;
    protected NPC npc;

    public void SetOwner(NPCFSM fsm, NPC npc)
    {
        this.fsm = fsm;
        this.npc = npc;
    }
    public virtual void OnAwake() {}
    public virtual void OnStart() {}
    public virtual void OnUpdate() {}
    public virtual void OnExit() {}
}
