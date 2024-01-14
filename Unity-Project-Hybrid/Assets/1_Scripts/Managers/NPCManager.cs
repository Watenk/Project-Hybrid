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

    public NPC AddNPC(GameObject prefab){
        NavMeshAgent agent = agentManager.AddAgent(prefab);
        NPC newNPC = agent.gameObject.AddComponent<NPC>();
        npcs.Add(newNPC);
        return newNPC;
    }

    public NPC AddNPC(GameObject prefab, Vector3 pos){
        NPC newNPC = AddNPC(prefab);
        newNPC.gameObject.transform.position = pos;
        return newNPC;
    }

    public NPC AddNPC(GameObject prefab, Vector3 pos, Quaternion rotation){
        NPC newNPC = AddNPC(prefab, pos);
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
}
