using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCSettings", menuName = "ScriptableObjects/NPCSettings")]
public class NPCSettings : ScriptableObject
{
    public static NPCSettings Instance { 
        get{
            if (instance == null){
                instance = Resources.Load<NPCSettings>("NPCSettings");
            }

            return instance;
        }
    }
    private static NPCSettings instance;

    [Header("Speed")]

    [Range(0.0f, 10.0f)]
    public float MinSpeed;
    [Range(0.0f, 10.0f)]
    public float MaxSpeed;
    [Range(0.0f, 10.0f)]
    public float Acceleration;
    public float MinIdleTime;
    public float MaxIdleTime;

    [Header("Location")]

    [Range(0.0f, 50.0f)]
    public float MinDistanceFromPlayer;
    [Range(0.0f, 50.0f)]
    public float MaxDistanceFromPlayer;
}
