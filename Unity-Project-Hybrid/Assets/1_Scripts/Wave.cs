using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

[SerializeField] [Serializable]
public class Wave
{
    public int NPCAmount;
    public int EnemyAmount;

    [Range(0.0f, 1.0f)] 
    public float NatureAmount;

    [Range(0.0f, 1.0f)]
    public float FireAmount;

    [Range(0.0f, 1.0f)]
    public float WaterAmount;

    [Range(0.0f, 50.0f)]
    public float MinDistanceFromPlayer;

    [Range(0.0f, 50.0f)]
    public float MaxDistanceFromPlayer;
}
