using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCManager 
{
    private List<NPC> npcs = new List<NPC>();

    //References
    private AgentManager agentManager;

    //--------------------------------------------

    public NPCManager(AgentManager agentManager){
        this.agentManager = agentManager;
    }

    public NPC AddNPC(Elements element, GameObject prefab){
        NavMeshAgent agent = agentManager.AddAgent(prefab);
        NPC newNPC = agent.gameObject.AddComponent<NPC>();
        npcs.Add(newNPC);
        AddIndicator(newNPC.gameObject);
        newNPC.SetElement(element);
        return newNPC;
    }

    public NPC AddNPC(Elements element, GameObject prefab, Vector3 pos){
        NPC newNPC = AddNPC(element, prefab);
        newNPC.gameObject.transform.position = pos;
        return newNPC;
    }

    public NPC AddNPC(Elements element, GameObject prefab, Vector3 pos, Quaternion rotation){
        NPC newNPC = AddNPC(element, prefab, pos);
        newNPC.gameObject.transform.rotation = rotation;
        return newNPC;
    }

    public int GetNPCCount(){
        return npcs.Count;
    }

    public void ClearNPCs(){
        for (int i = GetNPCCount() - 1; i >= 0; i--){
            RemoveNPC(npcs[i]);
        }
    }

    public void RemoveNPC(NPC removeNPC){
        npcs.Remove(removeNPC);
        agentManager.RemoveAgent(removeNPC.gameObject);
    }

    //--------------------------------------------------------

    private void AddIndicator(GameObject npc){
        GameObjectManager gameObjectManager = GameManager.Instance.GetGameObjectManager();
        GameObject prefab = GameSettings.Instance.NPCIndicator;
        GameObject indicator = gameObjectManager.AddGameObject(prefab, npc.transform.position);
        indicator.transform.parent = npc.transform;
    }
}
