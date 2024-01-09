using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance { get; private set; }

    private List<NPC> npcs = new List<NPC>();
    private List<Enemy> enemys = new List<Enemy>();

    public void Awake(){
        Instance = this;
    }

    public void AddNPC(GameObject currentPrefab, System.Type npcScript){

        // Instantiate
        Vector3 currentPos = GetRandomPosForNPC();
        GameObject npcInstance = Instantiate(currentPrefab, currentPos, Quaternion.identity);

        // Add script
        npcInstance.AddComponent(npcScript);
        NPC currentNPC = null;
        if (npcInstance.GetComponent<Enemy>() != null){
            currentNPC = npcInstance.GetComponent<Enemy>();
            enemys.Add(npcInstance.GetComponent<Enemy>());
        }
        else{
            currentNPC = npcInstance.GetComponent<NPC>();
            npcs.Add(npcInstance.GetComponent<NPC>());
        }
         
        if (currentNPC == null) { Debug.LogError(npcInstance.name + " Doesn't contain NPC"); }

        // Init NPC
        currentNPC.Init();
        currentNPC.Agent.speed = Random.Range(NPCSettings.Instance.MinSpeed, NPCSettings.Instance.MaxSpeed);
        currentNPC.Agent.acceleration = NPCSettings.Instance.Acceleration;
    }

    public void RemoveNPC(NPC currentNPC){

        if (currentNPC.GetComponent<Enemy>() != null){
            enemys.Remove(currentNPC.GetComponent<Enemy>());
        }
        else{
            npcs.Remove(currentNPC);
        }

        Destroy(currentNPC);
    }

    public void ClearAll(){
        foreach (NPC currentNPC in npcs){
            Destroy(currentNPC);
        }
        npcs.Clear();

        foreach (Enemy currentEnemy in enemys){
            Destroy(currentEnemy);
        }
        enemys.Clear();

    }

    public Vector3 GetRandomPosForNPC(){
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        float randomDistance = Random.Range(NPCSettings.Instance.MinDistanceFromPlayer, NPCSettings.Instance.MaxDistanceFromPlayer);
        float x = randomDistance * Mathf.Cos(randomAngle);
        float z = randomDistance * Mathf.Sin(randomAngle);

        return new Vector3(x, 1f, z);
    }

    public int GetEnemyAmount(){
        return enemys.Count;
    }
}
