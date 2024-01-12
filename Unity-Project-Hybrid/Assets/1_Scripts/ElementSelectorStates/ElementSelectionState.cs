using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSelectionState : BaseState<AttackManager>
{
    public override void OnStart()
    {
        HandTriggerDetector.Instance.OnTrigger += OnTrigger;

        blackboard.ActivateElement(Selectors.ElementSelector);
    }
    
    public override void OnExit()
    {
        HandTriggerDetector.Instance.OnTrigger -= OnTrigger;

        blackboard.DeActivateElement(Selectors.ElementSelector);
    }

    private void OnTrigger(Selectors trigger){

        if (trigger == Selectors.WaterSelector){
            blackboard.ActiveSelector = Selectors.WaterSelector;
            fsm.SwitchState(typeof(ElementChargeState));
        }

        if (trigger == Selectors.FireSelector){
            blackboard.ActiveSelector = Selectors.FireSelector;
            fsm.SwitchState(typeof(ElementChargeState));
        }

        if (trigger == Selectors.NatureSelector){
            blackboard.ActiveSelector = Selectors.NatureSelector;
            fsm.SwitchState(typeof(ElementChargeState));
        }

    }
}
