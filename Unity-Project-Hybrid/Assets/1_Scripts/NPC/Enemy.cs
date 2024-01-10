using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    public override void InitFSM()
    {
        fsm = new NPCFSM(this,
            new EnemyIdleState(),
            new EnemyWalkState(),
            new EnemyAttackState()
        );
        fsm.SwitchState(typeof(EnemyIdleState));
    }
}
