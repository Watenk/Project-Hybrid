using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSelectionState : BaseState<AttackManager>
{
    public override void OnStart()
    {
        HandTriggerDetector.Instance.OnTrigger += OnTrigger;

        blackboard.ActivateElement(SelectorsEnum.ElementSelector);
    }
    
    public override void OnExit()
    {
        HandTriggerDetector.Instance.OnTrigger -= OnTrigger;

        blackboard.DeActivateElement(SelectorsEnum.ElementSelector);
    }

    private void OnTrigger(RuinTrigger trigger){

        if (trigger.TriggerEnum == SelectorsEnum.WaterSelector){
            blackboard.ActiveSelector = SelectorsEnum.WaterSelector;
            fsm.SwitchState(typeof(ElementChargeState));
        }

        if (trigger.TriggerEnum == SelectorsEnum.FireSelector){
            blackboard.ActiveSelector = SelectorsEnum.FireSelector;
            fsm.SwitchState(typeof(ElementChargeState));
        }

        if (trigger.TriggerEnum == SelectorsEnum.NatureSelector){
            blackboard.ActiveSelector = SelectorsEnum.NatureSelector;
            fsm.SwitchState(typeof(ElementChargeState));
        }

    }
}
