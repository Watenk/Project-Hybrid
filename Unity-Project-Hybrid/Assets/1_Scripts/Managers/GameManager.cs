using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameObjects
    public HandTriggerDetector HandTriggerDetector;

    // Managers
    private GameObjectManager gameObjectManager;
    private AgentManager agentManager;
    private NPCManager npcManager;
    private EnemyManager enemyManager;
    private InputManager inputManager;
    private AnimationManager animationManager;
    private SoundManager soundManager;
    private RuinPatternManager weaponManager;
    private WaveManager waveManager;

    //------------------------------------------------

    public void Start(){
        InitManagers();

        waveManager.StartWave(0);
    }

    public void Update(){
        // Check when to progress to the next wave
    }

    //------------------------------------------------

    private void InitManagers(){

        // Monobehaviours
        GameObject gameObjectManagerGO = new GameObject();
        gameObjectManager = gameObjectManagerGO.AddComponent<GameObjectManager>();

        // Non-Monobehaviours
        agentManager = new AgentManager(gameObjectManager);
        npcManager = new NPCManager(agentManager);
        enemyManager = new EnemyManager(agentManager);
        inputManager = new InputManager();
        animationManager = new AnimationManager();
        soundManager = new SoundManager();
        weaponManager = new RuinPatternManager(gameObjectManager, HandTriggerDetector);
        waveManager = new WaveManager(enemyManager, npcManager);
    }
}
