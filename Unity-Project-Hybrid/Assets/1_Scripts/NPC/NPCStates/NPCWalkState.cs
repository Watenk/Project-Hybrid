using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkState : BaseState
{
    public override void OnStart()
    {   
        Vector3 newPos = NPCManager.Instance.GetRandomPosForNPC();
        npc.Agent.SetDestination(newPos);
    }

    public override void OnUpdate()
    {
        if (npc.Agent.remainingDistance <= 0.1f){
            fsm.SwitchState(typeof(NPCIdleState));
        }
    }
}
