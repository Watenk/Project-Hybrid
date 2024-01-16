using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int Health { get; private set; }

    public int MaxHealth { get; private set; }

    public void Start(){
    }

    public void Update(){
    }

    public void OnTriggerEnter(Collider other){
    }

    public void TakeDamage(int amount){
    }

    public void Die(){
        // ...Game-Over...
    }
}
