using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBlackboard 
{
    public NPC npc;
    public WaveManager waveManager;
    public NPCAnimationManager animationManager;
    public GameObjectManager gameObjectManager;
    public AttackManager attackManager;

    public NPCBlackboard(NPC npc){
        this.npc = npc;
        this.waveManager = GameManager.Instance.GetWaveManager();
        this.animationManager = GameManager.Instance.GetNPCAnimationManager();
        this.gameObjectManager = GameManager.Instance.GetGameObjectManager();
        this.attackManager = GameManager.Instance.GetAttackManager();
    }
}
