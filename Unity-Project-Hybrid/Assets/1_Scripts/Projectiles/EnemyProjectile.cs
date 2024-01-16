using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IProjectile
{
    public Elements Element { get; private set; } = Elements.Purple;

    public void Init(){
    }

    public void Charge(){
    }

    public void Shoot(){
    }

    public void Reset(){
        Destroy(this.gameObject);
    }
}
