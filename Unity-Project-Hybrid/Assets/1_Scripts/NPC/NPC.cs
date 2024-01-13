using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour, IDamageable
{
    public GameObject GameObject { get; private set; }
    public NavMeshAgent Agent { get; private set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public AnimationController animator;

    protected FSM<NPC> fsm;

    public void Init(int maxHealth){
        GameObject = this.gameObject;
        MaxHealth = maxHealth;
        Health = MaxHealth;
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<AnimationController>();
        
        InitFSM();

        if (Agent == null) { Debug.LogError(GameObject.name + " Doesn't contain a NavMeshAgent"); }
    }

    public virtual void InitFSM(){
        fsm = new FSM<NPC>(this,
            new NPCIdleState(),
            new NPCWalkState()
        );
        fsm.SwitchState(typeof(NPCIdleState));
    }

    public void FixedUpdate(){

        fsm.OnUpdate();
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health <= 0){
            Die();
        }
    }

    public void Die()
    {
        NPCManager.Instance.RemoveNPC(this);
    }
}
