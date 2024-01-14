using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RuinPatternManager
{
    private Elements element;
    private FSM<RuinPatternManager> ruinPatternFsm;
    private Dictionary<Elements, RuinPattern> ruinPatterns = new Dictionary<Elements, RuinPattern>();

    //References
    public HandTriggerDetector handTriggerDetector;
    private GameObjectManager gameObjectManager;

    //-----------------------------------------------------

    public RuinPatternManager(GameObjectManager gameObjectManager, HandTriggerDetector handTriggerDetector){

        this.gameObjectManager = gameObjectManager;
        this.handTriggerDetector = handTriggerDetector;
        if (handTriggerDetector == null) { Debug.LogError("HandTriggerDetector GameObject Doesn't contain the HandTriggerDetector Script"); } 

        ruinPatternFsm = new FSM<RuinPatternManager>(this,
            new RuinPatternIdleState(),
            new RuinPatternSelectionState(),
            new RuinPatternChargeState(),
            new RuinPatternShootState()
        );
        ruinPatternFsm.SwitchState(typeof(RuinPatternIdleState));

        AddRuinPattern(Elements.Selection, GameSettings.Instance.RuinPatternSelector);
        AddRuinPattern(Elements.Nature, GameSettings.Instance.NatureRuinPattern);
        AddRuinPattern(Elements.Water, GameSettings.Instance.WaterRuinPattern);
        AddRuinPattern(Elements.Fire, GameSettings.Instance.FireRuinPattern);

        ResetRuinPatterns();
    }

    public RuinPattern GetRuinPattern(Elements element){
        ruinPatterns.TryGetValue(element, out RuinPattern ruinPattern);
        return ruinPattern;
    }

    public void RuinPatternSetActive(Elements element, bool onOrOff){
        ruinPatterns.TryGetValue(element, out RuinPattern ruinPattern);
        ruinPattern.gameObject.SetActive(onOrOff);
    }

    public void ResetRuinPatterns(){
        foreach (KeyValuePair<Elements, RuinPattern> pair in ruinPatterns){
            RuinPattern ruinPattern = pair.Value;
            ruinPattern.gameObject.SetActive(false);
            ruinPattern.EnableAllRuins();
        }
    }

    public Elements GetElement(){
        return element;
    }

    public void SetElement(Elements element){
        this.element = element;
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
