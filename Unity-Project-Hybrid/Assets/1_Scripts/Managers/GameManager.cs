using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //References
    public HandTriggerDetector HandTriggerDetector;
    public GameObject Player;
    public GameObject Hand;

    // Managers
    private GameObjectManager gameObjectManager;
    private AgentManager agentManager;
    private NPCManager npcManager;
    private EnemyManager enemyManager;
    private InputManager inputManager;
    private NPCAnimationManager npcAnimationManager;
    private SoundManager soundManager;
    private AttackManager attackManager;
    private WaveManager waveManager;

    //------------------------------------------------

    public void Awake(){
        Instance = this;
    }

    public void Start(){
        InitManagers();

        waveManager.StartWave(0);
    }

    public void Update(){
        inputManager.OnUpdate();
        attackManager.OnUpdate();

        if (enemyManager.GetEnemyCount() == 0){
            waveManager.StartNextWave();
        }
    }

    public WaveManager GetWaveManager(){
        return waveManager;
    }

    public NPCAnimationManager GetNPCAnimationManager(){
        return npcAnimationManager;
    }

    public GameObjectManager GetGameObjectManager(){
        return gameObjectManager;
    }

    public AttackManager GetAttackManager(){
        return attackManager;
    }

    public NPCManager GetNPCManager(){
        return npcManager;
    }

    public EnemyManager GetEnemyManager(){
        return enemyManager;
    }

    //------------------------------------------------

    private void InitManagers(){

        // Monobehaviours
        GameObject gameObjectManagerGO = new GameObject();
        gameObjectManager = gameObjectManagerGO.AddComponent<GameObjectManager>();

        // Non-Monobehaviours
        agentManager = new AgentManager(gameObjectManager);
        enemyManager = new EnemyManager(agentManager);
        inputManager = new InputManager();
        npcAnimationManager = new NPCAnimationManager();
        soundManager = new SoundManager();
        attackManager = new AttackManager(gameObjectManager, HandTriggerDetector, inputManager);
        npcManager = new NPCManager(agentManager);
        waveManager = new WaveManager(enemyManager, npcManager);
    }
}
