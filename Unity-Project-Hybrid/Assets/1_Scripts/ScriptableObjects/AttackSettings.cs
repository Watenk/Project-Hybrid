using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "AttackSettings", menuName = "ScriptableObjects/AttackSettings")]
public class AttackSettings : ScriptableObject
{
    public static AttackSettings Instance { 
        get{
            if (instance == null){
                instance = Resources.Load<AttackSettings>("AttackSettings");

                if (instance == null) {Debug.Log("AttackSettings couln't be loaded...");}
            }

            return instance;
        }
    }
    private static AttackSettings instance;

    [Header("Prefabs")]
    public GameObject ElementSelector;
    public GameObject FireSelector;
    public GameObject NatureSelector;
    public GameObject WaterSelector;

    [Header("Position")]
    public float ElementSelectorDistanceFromCam;

    [Header("Cooldowns")]
    public float AttackCooldown;
    public float TriggerDelay;
    
    [Header("Ruins")]
    public int NatureRuinAmount;
    public int FireRuinAmount;
    public int WaterRuinAmount;
}
