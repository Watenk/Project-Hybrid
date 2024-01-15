using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBlackboard 
{
    public NPC npc;
    public WaveManager waveManager;
    public AnimationManager animationManager;
    public GameObjectManager gameObjectManager;
    public AttackManager attackManager;

    public NPCBlackboard(NPC npc){
        this.npc = npc;
        this.waveManager = GameManager.Instance.GetWaveManager();
        this.animationManager = GameManager.Instance.GetAnimationManager();
        this.gameObjectManager = GameManager.Instance.GetGameObjectManager();
        this.attackManager = GameManager.Instance.GetAttackManager();
    }
}
