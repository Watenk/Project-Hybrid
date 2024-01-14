using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RuinManager
{
    private FSM<RuinManager> ruinPatternFsm;
    private Dictionary<Elements, RuinPattern> ruinPatterns = new Dictionary<Elements, RuinPattern>();

    //References
    private GameObjectManager gameObjectManager;

    //-----------------------------------------------------

    public RuinManager(GameObjectManager gameObjectManager){

        this.gameObjectManager = gameObjectManager;

        ruinPatternFsm = new FSM<RuinManager>(this,
            new RuinPatternIdleState(),
            new RuinPatternSelectionState(),
            new RuinPatternChargeState(),
            new RuinPatternShootState()
        );
        ruinPatternFsm.SwitchState(typeof(RuinPatternIdleState));

        AddRuinPattern(Elements.Nature, GameSettings.Instance.NatureRuinPattern);
        AddRuinPattern(Elements.Water, GameSettings.Instance.WaterRuinPattern);
        AddRuinPattern(Elements.Fire, GameSettings.Instance.FireRuinPattern);
    }

    //---------------------------------------------------------

    private void AddRuinPattern(Elements element, GameObject prefab){
        GameObject ruinPatternGameObject = gameObjectManager.AddGameObject(prefab);
        RuinPattern ruinPattern = GetRuinPattern(ruinPatternGameObject);
        ruinPatterns.Add(element, ruinPattern);
    }

    private RuinPattern GetRuinPattern(GameObject gameObject){
        RuinPattern ruinPattern = gameObject.GetComponent<RuinPattern>();
        if (ruinPattern == null) { Debug.LogError(gameObject.name + " Doesn't contain RuinPattern"); }
        return ruinPattern;
    }
}

    // public SelectorsEnum selector;
    // public int RuinCount;

    // private List<RuinTrigger> enabledTriggers = new List<RuinTrigger>();
    // private List<RuinTrigger> disabledTriggers = new List<RuinTrigger>();

    // public void Start(){
    //     RuinCount = transform.childCount;

    //     for (int i = 0; i < RuinCount; i++)
    //     {
    //         GameObject currentRuin = transform.GetChild(i).gameObject;
    //         RuinTrigger currentTrigger = currentRuin.GetComponent<RuinTrigger>();
            
    //         if (currentTrigger == null) { Debug.LogError(this.gameObject.name + " is missing the trigger script"); }

    //         enabledTriggers.Add(currentTrigger);
    //     }
    // }

    // public void DisableRuin(RuinTrigger trigger){
        
    //     foreach (RuinTrigger currentTrigger in enabledTriggers){
    //         if (trigger == currentTrigger){
    //             enabledTriggers.Remove(currentTrigger);
    //             disabledTriggers.Add(currentTrigger);
    //             currentTrigger.gameObject.SetActive(false);
    //             break;
    //         }
    //     }
    // }

    // public void EnableRuin(RuinTrigger trigger){
        
    //     foreach (RuinTrigger currentTrigger in disabledTriggers){
    //         if (trigger == currentTrigger){
    //             enabledTriggers.Add(currentTrigger);
    //             disabledTriggers.Remove(currentTrigger);
    //             currentTrigger.gameObject.SetActive(true);
    //             break;
    //         }
    //     }
    // }

    // public void EnableAllRuins(){
        
    //     foreach (RuinTrigger currentTrigger in disabledTriggers){
    //         enabledTriggers.Add(currentTrigger);
    //         currentTrigger.gameObject.SetActive(true);
    //     }

    //     disabledTriggers.Clear();
    // }
