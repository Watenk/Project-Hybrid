using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : BaseState<NPCBlackboard>
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
            AttackOrIdle();
        }
    }

    public override void OnExit()
    {
        blackboard.animationManager.StopWalkingAnimation(blackboard.npc.gameObject);
    }

    //-----------------------------------------------------------------

    private void AttackOrIdle(){
        float random = Random.Range(0.0f, 100.0f);

        if (random < blackboard.waveManager.GetCurrentWave().AttackChance){
            fsm.SwitchState(typeof(EnemyAttackState));
        }
        else{
            fsm.SwitchState(typeof(EnemyIdleState));
        }
    }
}
