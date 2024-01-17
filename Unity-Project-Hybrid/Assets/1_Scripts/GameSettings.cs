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

    [Header("AgentPrefabs")]
    public GameObject FireNPCPrefab;
    public GameObject WaterNPCPrefab;
    public GameObject NatureNPCPrefab;

    [Header("IndicatorPrefabs")]
    public GameObject EnemyIndicator;
    public GameObject NPCIndicator;

    [Header("RuinPatternsPrefabs")]
    public GameObject RuinPatternSelector;
    public GameObject FireRuinPattern;
    public GameObject WaterRuinPattern;
    public GameObject NatureRuinPattern;

    [Header("ProjectilePrefabs")]
    public GameObject FireProjectile;
    public GameObject WaterProjectile;
    public GameObject NatureProjectile;
    public GameObject EnemyProjectile;

    [Header("Projectiles")]
    public float FireProjectileSpeed;
    public float WaterProjectileSpeed;
    public float NatureProjectileSpeed;
    public float EnemyProjectileSpeed;
    public float ProjectileDistanceFromCam;
    public float ShootDelay;

    [Header("Player")]
    public int PlayerHealth;

    [Header("Agents")]
    public float AgentMinIdleTime;
    public float AgentMaxIdleTime;
    public int AgentMinSpeed;
    public int AgentMaxSpeed;
    public int AgentHealth;
    public int AgentDeathDuration;

    [Header("Element Patterns")]
    public float ElementsHeight;
    public float ElementPatternDistanceFromCam;
    public float ElementAttackCooldown;

    [Header("Enemy's")]
    public float EnemyAttackDistance;
    public float EnemyAttackChargeDuration;

    [Header("Waves")]
    [Tooltip("The game starts at the first wave and when all the enemy's in that wave are dead it proceeds to the next wave")]
    public List<Wave> waves = new List<Wave>();
}
