using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveManager
{
    private int waveIndex;
    private List<Wave> waves;

    //References
    private EnemyManager enemyManager;
    private NPCManager npcManager;
    private Elements currentElement;

    //------------------------------------------

    public WaveManager(EnemyManager enemyManager, NPCManager npcManager){
        this.enemyManager = enemyManager;
        this.npcManager = npcManager;

        waves = GameSettings.Instance.waves;
    }

    public void StartWave(int index){
        waveIndex = index;
        Wave currentWave = waves[waveIndex];
        ClearAgents();
        SummonWaveAgents(currentWave);
    }

    public void StartNextWave(){
        waveIndex++;
        StartWave(waveIndex);
    }

    public Wave GetCurrentWave(){
        return waves[waveIndex];
    }

    //--------------------------------------------

    private void SummonWaveAgents(Wave wave){

        // Add NPC's
        for (int i = 0; i < wave.NPCAmount; i++){
            Vector3 agentPos = GetAgentPos(wave);
            GameObject agentPrefab = GetAgentPrefab(wave);
            npcManager.AddNPC(currentElement, agentPrefab, agentPos);
        }

        // Add Enemy's
        for (int i = 0; i < wave.EnemyAmount; i++){
            Vector3 agentPos = GetAgentPos(wave);
            GameObject agentPrefab = GetAgentPrefab(wave);
            enemyManager.AddEnemy(currentElement, agentPrefab, agentPos);
        }
    }

    private void ClearAgents(){
        enemyManager.ClearEnemys();
        npcManager.ClearNPCs();
    }

    public Vector3 GetAgentPos(Wave wave){
        float randomAngle = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
        float randomDistance = UnityEngine.Random.Range(wave.MinDistanceFromPlayer, wave.MaxDistanceFromPlayer);
        float x = randomDistance * Mathf.Cos(randomAngle);
        float z = randomDistance * Mathf.Sin(randomAngle);

        return new Vector3(x, 1f, z);
    }

    private GameObject GetAgentPrefab(Wave currentWave){
        
        float totalAmount = currentWave.NatureAmount + currentWave.FireAmount + currentWave.WaterAmount;
        float randomValue = UnityEngine.Random.Range(0f, totalAmount);

        if (randomValue < currentWave.NatureAmount){
            currentElement = Elements.Nature;
            return GameSettings.Instance.NatureNPCPrefab;
        }
        else if (randomValue < currentWave.NatureAmount + currentWave.FireAmount){
            currentElement = Elements.Fire;
            return GameSettings.Instance.FireNPCPrefab;
        }
        else{
            currentElement = Elements.Water;
            return GameSettings.Instance.WaterNPCPrefab;
        }
    }
}
