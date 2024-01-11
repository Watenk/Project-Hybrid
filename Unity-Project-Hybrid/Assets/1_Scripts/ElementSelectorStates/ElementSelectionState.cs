using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSelectionState : BaseState<AttackManager>
{
    public override void OnStart()
    {
        HandTriggerDetector.Instance.OnWaterElementSelector += OnElementWaterSelector;
        HandTriggerDetector.Instance.OnNatureElementSelector += OnElementNatureSelector;
        HandTriggerDetector.Instance.OnFireElementSelector += OnElementFireSelector;

        blackboard.ActivateElement("Selector");
    }
    
    public override void OnExit()
    {
        HandTriggerDetector.Instance.OnWaterElementSelector += OnElementWaterSelector;
        HandTriggerDetector.Instance.OnNatureElementSelector += OnElementNatureSelector;
        HandTriggerDetector.Instance.OnFireElementSelector += OnElementFireSelector;

        blackboard.DeActivateElement("Selector");
    }

    private void OnElementWaterSelector(){
        blackboard.ActiveElement = "Water";
        fsm.SwitchState(typeof(ElementChargeState));
    }

    private void OnElementNatureSelector(){
        blackboard.ActiveElement = "Nature";
        fsm.SwitchState(typeof(ElementChargeState));
    }

    private void OnElementFireSelector(){
        blackboard.ActiveElement = "Fire";
        fsm.SwitchState(typeof(ElementChargeState));
    }
}
