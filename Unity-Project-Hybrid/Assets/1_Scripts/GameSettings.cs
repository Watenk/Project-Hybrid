using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public static GameSettings Instance { 
        get{
            if (instance == null){
                instance = Resources.Load<GameSettings>("GameSettings");

                if (instance == null) {Debug.Log("GameSettings couldn't be loaded...");}
            }
            return instance;
        }
    }
    private static GameSettings instance;

    [Header("Prefabs")]
    public GameObject FireNPCPrefab;
    public GameObject WaterNPCPrefab;
    public GameObject NatureNPCPrefab;
    public GameObject RuinPatternSelector;
    public GameObject FireRuinPattern;
    public GameObject WaterRuinPattern;
    public GameObject NatureRuinPattern;

    [Header("Waves")]
    [Tooltip("The game starts at the first wave and when all the enemy's in that wave are dead it proceeds to the next wave")]
    public List<Wave> waves = new List<Wave>();

    [Header("Creatures")]
    public float MinIdleTime;
    public float MaxIdleTime;

    //[Header("Projectiles")]
}
