using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int currentWaveIndex;
    private Wave currentWave;

    public void Awake(){
        Instance = this;
    }

    public void Start(){
        StartWave(currentWaveIndex);
    }

    public void Update(){
        // Fix This
        if (CheckIfWaveIsDone()){
            currentWaveIndex++;

            if (currentWaveIndex < GameSettings.Instance.waves.Count){
                StartWave(currentWaveIndex);
            }
        }
    }

    public void StartWave(int index){
        
        currentWave = GameSettings.Instance.waves[index];
        NPCManager.Instance.ClearAll();

        for (int i = 0; i < currentWave.NPCAmount; i++){
            NPCManager.Instance.AddNPC(GetNPCPrefab(currentWave), typeof(NPC), currentWave);
        }

        for (int i = 0; i < currentWave.EnemyAmount; i++){
            NPCManager.Instance.AddNPC(GetNPCPrefab(currentWave), typeof(Enemy), currentWave);
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
    }

    public bool CheckIfWaveIsDone(){
        if (NPCManager.Instance.GetEnemyAmount() == 0){
            return true;
        }

        return false;
    }

    public Wave GetCurrentWave(){
        return currentWave;
    }

    private GameObject GetNPCPrefab(Wave currentWave){
        
        float totalAmount = currentWave.NatureAmount + currentWave.FireAmount + currentWave.WaterAmount;
        float randomValue = Random.Range(0f, totalAmount);

        if (randomValue < currentWave.NatureAmount){
            return GameSettings.Instance.NatureNPCPrefab;
        }
        else if (randomValue < currentWave.NatureAmount + currentWave.FireAmount){
            return GameSettings.Instance.FireNPCPrefab;
        }
        else{
            return GameSettings.Instance.WaterNPCPrefab;
        }
    }
}
