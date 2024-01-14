using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager 
{
    private List<Enemy> enemies = new List<Enemy>();

    //References
    private AgentManager agentManager;

    //-------------------------------------

    public EnemyManager(AgentManager agentManager){
        this.agentManager = agentManager;
    }

    public Enemy AddEnemy(GameObject prefab){
        NavMeshAgent agent = agentManager.AddAgent(prefab);
        Enemy newEnemy = agent.gameObject.AddComponent<Enemy>();
        enemies.Add(newEnemy);
        return newEnemy;
    }

    public Enemy AddEnemy(GameObject prefab, Vector3 pos){
        Enemy newEnemy = AddEnemy(prefab);
        newEnemy.gameObject.transform.position = pos;
        return newEnemy;
    }

    public Enemy AddEnemy(GameObject prefab, Vector3 pos, Quaternion rotation){
        Enemy newEnemy = AddEnemy(prefab, pos);
        newEnemy.gameObject.transform.rotation = rotation;
        return newEnemy;
    }

    public int GetEnemyCount(){
        return enemies.Count;
    }

    public void ClearEnemys(){
        for (int i = GetEnemyCount() - 1; i >= 0; i--){
            RemoveEnemy(enemies[i]);
        }
    }

    public void RemoveEnemy(Enemy removeEnemy){
        enemies.Remove(removeEnemy);
        agentManager.RemoveAgent(removeEnemy.gameObject);
    }
}
