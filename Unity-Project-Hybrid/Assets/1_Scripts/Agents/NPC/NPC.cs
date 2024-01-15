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
    public Elements Element { get; private set; }

    protected FSM<NPCBlackboard> fsm;

    //------------------------------------------------

    public void Start(){

        GameObject = this.gameObject;
        MaxHealth = GameSettings.Instance.AgentHealth;
        Health = MaxHealth;
        Agent = GetComponent<NavMeshAgent>();
        
        InitFSM();

        if (Agent == null) { Debug.LogError(GameObject.name + " Doesn't contain a NavMeshAgent"); }
    }

    public virtual void InitFSM(){
        fsm = new FSM<NPCBlackboard>(new NPCBlackboard(this),
            new NPCIdleState(),
            new NPCWalkState()
        );
        fsm.SwitchState(typeof(NPCIdleState));
    }

    public void FixedUpdate(){

        fsm.OnUpdate();
    }

    public void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Projectile")){
            IProjectile projectile = other.gameObject.GetComponent<IProjectile>();

            if (projectile == null) { Debug.LogError(other.gameObject.name + " Doesn't contain IProjectile"); }

            if (Element == Elements.Water){
                if (projectile.Element == Elements.Nature){
                    TakeDamage(1);
                }
            }
            if (Element == Elements.Nature){
                if (projectile.Element == Elements.Fire){
                    TakeDamage(1);
                }
            }
            if (Element == Elements.Fire){
                if (projectile.Element == Elements.Water){
                    TakeDamage(1);
                }
            }
        }
    }

    public void SetElement(Elements element){
        this.Element = element;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health <= 0){
            Die();
        }
    }

    public virtual void Die()
    {
        GameManager.Instance.GetNPCManager().RemoveNPC(this);
    }
}
