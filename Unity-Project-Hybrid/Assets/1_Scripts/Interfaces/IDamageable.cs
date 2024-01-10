using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    public int Health { get; }
    public int MaxHealth { get; }

    public void TakeDamage(int amount);
    public void Die();
}
