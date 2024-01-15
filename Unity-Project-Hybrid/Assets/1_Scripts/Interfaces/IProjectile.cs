using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    public Elements Element { get; }

    public void Init();
    public void Charge();
    public void Shoot();
    public void Reset();
}
