using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public static GameSettings Instance { 
        get{
            if (instance == null){
                instance = Resources.Load<GameSettings>("GameSettings");

                if (instance == null) {Debug.Log("AHHH");}
            }

            return instance;
        }
    }
    private static GameSettings instance;

    [Header("Prefabs")]
    public GameObject FireNPCPrefab;
    public GameObject WaterNPCPrefab;
    public GameObject NatureNPCPrefab;

    [Header("Waves")]
    public List<Wave> waves = new List<Wave>();
}
