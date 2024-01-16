using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState<NPCBlackboard>
{
    private float attackChargeDurationTimer;
    private bool isStopped;

    public override void OnStart()
    {
        blackboard.npc.Agent.SetDestination(GameManager.Instance.Player.transform.position);
        attackChargeDurationTimer = GameSettings.Instance.EnemyAttackChargeDuration;
        isStopped = false;
    }

    public override void OnUpdate()
    {
        if (blackboard.npc.Agent.remainingDistance <= GameSettings.Instance.EnemyAttackDistance){
            AttackPlayer();
        }
    }

    //-----------------------------------------------

    private void AttackPlayer(){

        if (!isStopped){
            blackboard.npc.Agent.SetDestination(blackboard.npc.transform.position);
            GameManager.Instance.GetNPCAnimationManager().PlayAttackAnimation(blackboard.npc.gameObject);
        }

        isStopped = true;        

        if (attackChargeDurationTimer <= 0){
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
