using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : MonoBehaviour, IProjectile
{
    public Elements Element { get; private set; }
    public Elements ElementProjectile;

    public void Init(){
        Element = ElementProjectile;
    }

    public void Charge(){
    }

    public void Shoot(){
    }

    public void Reset(){
    }
}
