using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentWave;

    public void Start(){
        StartWave(currentWave);
    }

    public void Update(){
        // Fix This
        if (CheckIfWaveIsDone()){
            currentWave++;

            if (currentWave < GameSettings.Instance.waves.Count){
                StartWave(currentWave);
            }
        }
    }

    public void StartWave(int index){
        
        Wave currentWave = GameSettings.Instance.waves[index];
        NPCManager.Instance.ClearAll();

        for (int i = 0; i < currentWave.NPCAmount; i++){
            NPCManager.Instance.AddNPC(GetNPCPrefab(currentWave), typeof(NPC));
        }

        for (int i = 0; i < currentWave.EnemyAmount; i++){
            NPCManager.Instance.AddNPC(GetNPCPrefab(currentWave), typeof(Enemy));
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
    }

    public bool CheckIfWaveIsDone(){
        if (NPCManager.Instance.GetEnemyAmount() == 0){
            return true;
        }

        return false;
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
