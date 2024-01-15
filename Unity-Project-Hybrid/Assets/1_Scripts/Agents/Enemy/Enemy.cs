using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    public override void InitFSM()
    {
        fsm = new FSM<NPCBlackboard>(new NPCBlackboard(this),
            new EnemyIdleState(),
            new EnemyWalkState(),
            new EnemyAttackState()
        );
        fsm.SwitchState(typeof(EnemyIdleState));
    }

    public override void Die()
    {
        GameManager.Instance.GetEnemyManager().RemoveEnemy(this);
    }
}
