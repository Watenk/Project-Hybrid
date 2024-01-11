using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkState : BaseState<NPC>
{
    public override void OnStart()
    {   
        Vector3 newPos = NPCManager.Instance.GetRandomPosForNPC();
        blackboard.Agent.SetDestination(newPos);
        blackboard.animator.PlayWalkingAnimation();
    }

    public override void OnUpdate()
    {
        if (blackboard.Agent.remainingDistance <= 0.1f){
            fsm.SwitchState(typeof(NPCIdleState));
        }
    }

    public override void OnExit()
    {
        blackboard.animator.StopWalkAnimation();
    }
}
