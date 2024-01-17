using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AttackManager : IUpdateable
{
    private bool active;
    private float attackcooldownTimer;
    private Elements element;
    private FSM<AttackManager> ruinPatternFsm;
    private Dictionary<Elements, RuinPattern> ruinPatterns = new Dictionary<Elements, RuinPattern>();
    private Dictionary<Elements, GameObject> projectiles = new Dictionary<Elements, GameObject>();

    //References
    public HandTriggerDetector handTriggerDetector;
    private GameObjectManager gameObjectManager;
    private InputManager inputManager;

    //-----------------------------------------------------

    public AttackManager(GameObjectManager gameObjectManager, HandTriggerDetector handTriggerDetector, InputManager inputManager){

        inputManager.OnRIndexTrigger += OnIndexTrigger;
        inputManager.OnRIndexTriggerLoose += OnIndexTriggerLoose;

        active = false;
        this.gameObjectManager = gameObjectManager;
        this.handTriggerDetector = handTriggerDetector;
        this.inputManager = inputManager;
        if (handTriggerDetector == null) { Debug.LogError("HandTriggerDetector GameObject Doesn't contain the HandTriggerDetector Script"); } 

        // FSM
        ruinPatternFsm = new FSM<AttackManager>(this,
            new RuinPatternIdleState(),
            new RuinPatternSelectionState(),
            new RuinPatternChargeState(),
            new RuinPatternShootState()
        );
        ruinPatternFsm.SwitchState(typeof(RuinPatternIdleState));

        // Projectiles
        AddProjectile(Elements.Nature, GameSettings.Instance.NatureProjectile);
        AddProjectile(Elements.Water, GameSettings.Instance.WaterProjectile);
        AddProjectile(Elements.Fire, GameSettings.Instance.FireProjectile);

        // Ruin Patterns
        AddRuinPattern(Elements.Selection, GameSettings.Instance.RuinPatternSelector);
        AddRuinPattern(Elements.Nature, GameSettings.Instance.NatureRuinPattern);
        AddRuinPattern(Elements.Water, GameSettings.Instance.WaterRuinPattern);
        AddRuinPattern(Elements.Fire, GameSettings.Instance.FireRuinPattern);

        ResetRuinPatterns();
    }

    public void OnUpdate()
    {
        if (attackcooldownTimer >= 0){
            attackcooldownTimer -= Time.deltaTime;
        }

        ruinPatternFsm.OnUpdate();
    }

    // Ruins

    public RuinPattern GetRuinPattern(Elements element){
        ruinPatterns.TryGetValue(element, out RuinPattern ruinPattern);
        return ruinPattern;
    }

    public void RuinPatternSetActive(Elements element, bool onOrOff){
        ruinPatterns.TryGetValue(element, out RuinPattern ruinPattern);
        ruinPattern.gameObject.SetActive(onOrOff);
        SetObjectInFrontOfPlayer(ruinPattern.gameObject, GameSettings.Instance.ElementPatternDistanceFromCam);
    }

    public void ResetRuinPatterns(){
        foreach (KeyValuePair<Elements, RuinPattern> pair in ruinPatterns){
            RuinPattern ruinPattern = pair.Value;
            ruinPattern.EnableAllRuins();
            ruinPattern.gameObject.SetActive(false);
        }
    }

    // Projectiles

    public void ResetProjectiles(){
        foreach (KeyValuePair<Elements, GameObject> pair in projectiles){
            
            IProjectile projectile = GetProjectile(pair.Key);
            projectile.Reset();
            
            GameObject projectileGameObject = pair.Value;
            projectileGameObject.SetActive(false);
        }
    }

    public void ProjectileSetActive(Elements element, bool onOrOff){
        projectiles.TryGetValue(element, out GameObject projectile);
        projectile.SetActive(onOrOff);
        SetObjectInFrontOfPlayer(projectile, GameSettings.Instance.ProjectileDistanceFromCam);
    }

    public void SetProjectileRotation(Elements element, Quaternion rotation){
        projectiles.TryGetValue(element, out GameObject projectile);
        projectile.transform.rotation = rotation;
    }

    public IProjectile GetProjectile(Elements element){
        projectiles.TryGetValue(element, out GameObject projectileGameObject);
        IProjectile projectile = projectileGameObject.GetComponent<IProjectile>();
        if (projectile == null) { Debug.LogError(projectileGameObject.name + " Doesn't contain the IProjectile Interface"); }
        return projectile;
    }

    // Elements

    public Elements GetElement(){
        return element;
    }

    public void SetElement(Elements element){
        this.element = element;
    }

    //---------------------------------------------------------

    // Events

    private void OnIndexTrigger(){
        if (!active && attackcooldownTimer <= 0){
            ruinPatternFsm.SwitchState(typeof(RuinPatternSelectionState));
            active = true;
        }
    }

    private void OnIndexTriggerLoose(){
        if (active){
            ruinPatternFsm.SwitchState(typeof(RuinPatternIdleState));
            active = false;
            attackcooldownTimer = GameSettings.Instance.ElementAttackCooldown;
        }
    }

    // Ruins

    private void AddRuinPattern(Elements element, GameObject prefab){
        GameObject ruinPatternGameObject = gameObjectManager.AddGameObject(prefab);
        RuinPattern ruinPattern = GetRuinPattern(ruinPatternGameObject);
        ruinPatterns.Add(element, ruinPattern);
        ruinPattern.Init();
    }

    private RuinPattern GetRuinPattern(GameObject gameObject){
        RuinPattern ruinPattern = gameObject.GetComponent<RuinPattern>();
        if (ruinPattern == null) { Debug.LogError(gameObject.name + " Doesn't contain RuinPattern"); }
        return ruinPattern;
    }

    // Projectiles
    private void AddProjectile(Elements element, GameObject prefab){
        GameObject projectileGameObject = gameObjectManager.AddGameObject(prefab);
        projectiles.Add(element, projectileGameObject);
        GetProjectile(element).Init();
        projectileGameObject.SetActive(false);
    }

    // Other

    private void SetObjectInFrontOfPlayer(GameObject currentObject, float distance){
        Vector3 newPos = Camera.main.transform.position + Camera.main.transform.forward * distance;
        newPos.y = GameSettings.Instance.ElementsHeight;
        currentObject.transform.position = newPos;
        currentObject.transform.LookAt(Camera.main.transform);
        currentObject.transform.eulerAngles = new Vector3(0, currentObject.transform.eulerAngles.y, currentObject.transform.eulerAngles.z);
    }
}
