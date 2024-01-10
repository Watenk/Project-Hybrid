using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public List<GameObject> NPCPrefabs = new List<GameObject>();
    public List<GameObject> EnemyPrefabs = new List<GameObject>();
    public static NPCManager Instance { get; private set; }

    private List<NPC> npcs = new List<NPC>();

    public void Awake(){
        Instance = this;
    }

    public void Start(){
        InstanceNPCs();
    }

    public NPC SpawnNPC(GameObject npcPrefab, Vector3 spawnPos){
        
        if (npcPrefab.GetComponent<NPC>() == null){
            Debug.LogError(npcPrefab.name + " Doesn't contain NPC");
            return default;
        }

        GameObject npcInstance = Instantiate(npcPrefab, spawnPos, Quaternion.identity);
        NPC currentNPC = npcInstance.GetComponent<NPC>();
        npcs.Add(currentNPC);
        return currentNPC;
    }

    public void RemoveNPC(NPC currentNPC){
        npcs.Remove(currentNPC);
        Destroy(currentNPC);
    }

    public Vector3 GetRandomNPCPos(){
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        float randomDistance = Random.Range(NPCSettings.Instance.MinDistanceFromPlayer, NPCSettings.Instance.MaxDistanceFromPlayer);
        float x = randomDistance * Mathf.Cos(randomAngle);
        float z = randomDistance * Mathf.Sin(randomAngle);

        return new Vector3(x, 1f, z);
    }

    public void AddRandomNPC(GameObject currentPrefab){
        Vector3 currentPos = GetRandomNPCPos();
        NPC currentNPC = SpawnNPC(currentPrefab, currentPos);
        currentNPC.Init();
        currentNPC.Agent.speed = Random.Range(NPCSettings.Instance.MinSpeed, NPCSettings.Instance.MaxSpeed);
        currentNPC.Agent.acceleration = NPCSettings.Instance.Acceleration;
    }

    private void InstanceNPCs(){
        
        for (int i = 0; i < NPCSettings.Instance.TotalAgentAmount; i++){
            
            if (Random.Range(0.0f, 100.0f) <= NPCSettings.Instance.EnemyPercentage){
                AddRandomNPC(GetRandomEnemyPrefab());
            }
            else{
                AddRandomNPC(GetRandomNPCPrefab());
            }
        }
    }

    private GameObject GetRandomNPCPrefab(){
        int index = Random.Range(0, NPCPrefabs.Count - 1);
        return NPCPrefabs[index];
    }

    private GameObject GetRandomEnemyPrefab(){
        int index = Random.Range(0, EnemyPrefabs.Count - 1);
        return EnemyPrefabs[index];
    }
}
