using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager
{
    private List<NavMeshAgent> agents = new List<NavMeshAgent>();

    //References
    private GameObjectManager gameObjectManager;

    //-----------------------------------------------------

    public AgentManager(GameObjectManager gameObjectManager){
        this.gameObjectManager = gameObjectManager;
    }

    public NavMeshAgent AddAgent(GameObject prefab){
        GameObject instance = gameObjectManager.AddGameObject(prefab);
        NavMeshAgent agent = GetAgent(instance);
        agent.speed = Random.Range(GameSettings.Instance.AgentMinSpeed, GameSettings.Instance.AgentMaxSpeed);
        agents.Add(agent);
        return agent;
    }

    public NavMeshAgent AddAgent(GameObject prefab, Vector3 pos){
        NavMeshAgent agent = AddAgent(prefab);
        agent.gameObject.transform.position = pos;
        return agent;
    }

    public NavMeshAgent AddAgent(GameObject prefab, Vector3 pos, Quaternion rotation){
        NavMeshAgent agent = AddAgent(prefab, pos);
        agent.gameObject.transform.rotation = rotation;
        return agent;
    }

    public NavMeshAgent GetAgent(int index){
        return agents[index];
    }

    public int GetAgentCount(){
        return agents.Count;
    }

    public void RemoveAgent(GameObject agentGameObject){
        NavMeshAgent agent = GetAgent(agentGameObject);
        agents.Remove(agent);
        gameObjectManager.RemoveGameObject(agentGameObject);
    }

    //------------------------------------------------------

    private NavMeshAgent GetAgent(GameObject agentGameObject){
        NavMeshAgent agent = agentGameObject.GetComponent<NavMeshAgent>();
        if (agent == null) { Debug.LogError(agentGameObject.name + " Doesn't contain a NavMeshAgent"); }
        return agent;
    }
}
