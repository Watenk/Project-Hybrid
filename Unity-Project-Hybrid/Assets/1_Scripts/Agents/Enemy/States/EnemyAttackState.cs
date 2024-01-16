using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState<NPCBlackboard>
{
    private float attackChargeDurationTimer;

    public override void OnStart()
    {
        blackboard.npc.Agent.SetDestination(GameManager.Instance.Player.transform.position);
        attackChargeDurationTimer = GameSettings.Instance.EnemyAttackChargeDuration;
    }

    public override void OnUpdate()
    {
        if (blackboard.npc.Agent.remainingDistance <= GameSettings.Instance.EnemyAttackDistance){
            AttackPlayer();
        }
    }

    //-----------------------------------------------

    private void AttackPlayer(){
        blackboard.npc.Agent.isStopped = true;

        if (attackChargeDurationTimer <= 0){
            blackboard.npc.Agent.isStopped = false;
            GameObject enemyProjectile = GameManager.Instance.GetGameObjectManager().AddGameObject(GameSettings.Instance.EnemyProjectile, blackboard.npc.gameObject.transform.position);
            enemyProjectile.transform.LookAt(GameManager.Instance.Player.gameObject.transform.position);
            Rigidbody enemyProjectileRB = enemyProjectile.GetComponent<Rigidbody>();
            Vector3 shootDirection = (GameManager.Instance.Player.gameObject.transform.position - enemyProjectile.transform.position).normalized;
            enemyProjectileRB.AddForce(shootDirection * GameSettings.Instance.EnemyProjectileSpeed);
            fsm.SwitchState(typeof(EnemyIdleState));
        }

        attackChargeDurationTimer -= Time.deltaTime;
    }
}
