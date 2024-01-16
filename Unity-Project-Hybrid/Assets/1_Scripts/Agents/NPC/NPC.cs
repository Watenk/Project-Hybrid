using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    protected float deathDurationTimer;
    
    private bool death = false;

    //------------------------------------------------

    public void Start(){

        GameObject = this.gameObject;
        MaxHealth = GameSettings.Instance.AgentHealth;
        Health = MaxHealth;
        Agent = GetComponent<NavMeshAgent>();
        deathDurationTimer = GameSettings.Instance.AgentDeathDuration;
        
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
        if (!death){
            fsm.OnUpdate();
        }
        else{
            DeathDuration();
        }
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

    public void Die()
    {
        death = true;
        Agent.SetDestination(this.gameObject.transform.position);
        GameManager.Instance.GetNPCAnimationManager().PlayDeathAnimation(this.gameObject);
    }

    public virtual void DeathDuration(){
        if (deathDurationTimer <= 0){
            GameManager.Instance.Player.GetComponent<Player>().TakeDamage(1);
            GameManager.Instance.GetNPCManager().RemoveNPC(this);
        }
        else{
            deathDurationTimer -= Time.deltaTime;
        }
    }
}
