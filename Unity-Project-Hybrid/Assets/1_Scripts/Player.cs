using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Player : MonoBehaviour, IDamageable
{
    public int Health { get; private set; }

    public int MaxHealth { get; private set; }

    public void Start(){
        MaxHealth = GameSettings.Instance.PlayerHealth;
        Health = MaxHealth;
    }

    public void Update(){
    }

    public void OnTriggerEnter(Collider other){

        if (other.gameObject.layer == LayerMask.NameToLayer("Projectile")){

            IProjectile projectile = other.gameObject.GetComponent<IProjectile>();

            if (projectile == null) { Debug.LogError(other.gameObject.name + " Doesn't contain IProjectile"); }

            if (projectile.Element == Elements.Purple){
                TakeDamage(1);
                projectile.Reset();
            }
        }
    }

    public void TakeDamage(int amount){

        Health -= amount;

        if (Health <= 0){
            Die();
        }
    }

    public void Die(){
        // ...Game-Over...
        Debug.LogWarning("GameOver");
    }
}
