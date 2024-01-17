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
    public GameObject GameOverScreen;
    public AudioSource MusicSource;
    public AudioSource Sfx0Source;
    public AudioSource Sfx1Source;

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

    private bool gameOver;

    //------------------------------------------------

    public void Awake(){
        Instance = this;
        Application.targetFrameRate = 120;
    }

    public void Start(){
        InitManagers();

        gameOver = false;
        waveManager.StartWave(0);
    }

    public void Update(){
        if (!gameOver){
            inputManager.OnUpdate();
            attackManager.OnUpdate();

            if (enemyManager.GetEnemyCount() == 0){
                waveManager.StartNextWave();
            }
        }
    }

    public void GameOver(){
        gameOver = true;
        enemyManager.ClearEnemys();
        npcManager.ClearNPCs();
        GameOverScreen.SetActive(true);
    }

    // Getters
    //--------------------------------------------

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

    public SoundManager GetSoundManager(){
        return soundManager;
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
        soundManager = new SoundManager(MusicSource, Sfx0Source, Sfx1Source);
        attackManager = new AttackManager(gameObjectManager, HandTriggerDetector, inputManager);
        npcManager = new NPCManager(agentManager);
        waveManager = new WaveManager(enemyManager, npcManager);
    }
}
