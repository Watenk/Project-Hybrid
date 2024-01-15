using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour, IProjectile
{
    public Elements ElementProjectile;
    public Elements Element { get; private set; }

    private Rigidbody rb;

    public void Init(){
        Element = ElementProjectile;
        rb = GetComponent<Rigidbody>();
        if (rb == null) { Debug.LogError("NatureProjectile is missing a RigidBody"); } 
    }

    public void Charge(){
    }

    public void Shoot(){
        rb.AddForce(this.gameObject.transform.forward * GameSettings.Instance.FireProjectileSpeed);
    }

    public void Reset(){
        rb.velocity = Vector3.zero;
    }
}
