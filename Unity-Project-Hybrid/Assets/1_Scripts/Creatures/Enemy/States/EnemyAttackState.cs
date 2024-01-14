using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState<NPCBlackboard>
{
    public override void OnStart()
    {
        blackboard.npc.Agent.SetDestination(GameManager.Instance.Player.transform.position);
    }

    public override void OnUpdate()
    {
        if (blackboard.npc.Agent.remainingDistance <= GameSettings.Instance.EnemyAttackDistance){
            AttackPlayer();
            fsm.SwitchState(typeof(EnemyIdleState));
        }
    }

    //-----------------------------------------------

    private void AttackPlayer(){
        blackboard.gameObjectManager.AddGameObject(blackboard.attackManager.GetProjectile(blackboard.attackManager.GetElement()));
    }
}
