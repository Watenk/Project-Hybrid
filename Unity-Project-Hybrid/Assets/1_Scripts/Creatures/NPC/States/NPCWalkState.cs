using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkState : BaseState<NPC>
{
    public override void OnStart()
    {   
        Vector3 newPos = blackboard.GetWaveManager().GetAgentPos(blackboard.GetWaveManager().GetCurrentWave()); 
        blackboard.Agent.SetDestination(newPos);
        blackboard.GetAnimationManager().PlayWalkingAnimation(blackboard.gameObject);
    }

    public override void OnUpdate()
    {
        if (blackboard.Agent.remainingDistance <= 0.1f){
            fsm.SwitchState(typeof(NPCIdleState));
        }
    }

    public override void OnExit()
    {
        blackboard.GetAnimationManager().StopWalkingAnimation(blackboard.gameObject);
    }
}