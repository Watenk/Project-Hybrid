using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentSettings", menuName = "ScriptableObjects/AgentSettings")]
public class AgentSettings : ScriptableObject
{
    public static AgentSettings Instance { get; private set; }

    [Header("Speed")]

    [Range(0.0f, 10.0f)]
    public float MinSpeed;
    [Range(0.0f, 10.0f)]
    public float MaxSpeed;
    [Range(0.0f, 10.0f)]
    public float Acceleration;

    [Header("Amount")]
    public int TotalAgentAmount;
    [Range(0.0f, 100.0f)]
    public float EnemyPercentage;

    [Header("Location")]

    [Range(0.0f, 50.0f)]
    public float MinDistanceFromPlayer;
    [Range(0.0f, 50.0f)]
    public float MaxDistanceFromPlayer;

    private void OnEnable(){
        Instance = this;
    }
}
