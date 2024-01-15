using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkState : BaseState<NPCBlackboard>
{
    public override void OnStart()
    {   
        Vector3 newPos = blackboard.waveManager.GetAgentPos(blackboard.waveManager.GetCurrentWave()); 
        blackboard.npc.Agent.SetDestination(newPos);
        blackboard.animationManager.PlayWalkingAnimation(blackboard.npc.gameObject);
    }

    public override void OnUpdate()
    {
        if (blackboard.npc.Agent.remainingDistance <= 0.1f){
            fsm.SwitchState(typeof(NPCIdleState));
        }
    }

    public override void OnExit()
    {
        blackboard.animationManager.StopWalkingAnimation(blackboard.npc.gameObject);
    }
}