using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementChargeState : BaseState<AttackManager>
{
    private int RuinHits;
    private int TotalRuinHits;

    public override void OnStart()
    {
        HandTriggerDetector.Instance.OnTrigger += OnTrigger;

        if (blackboard.ActiveSelector == Selectors.NatureSelector){
            TotalRuinHits = AttackSettings.Instance.NatureRuinAmount;
        }

        if (blackboard.ActiveSelector == Selectors.WaterSelector){
            TotalRuinHits = AttackSettings.Instance.WaterRuinAmount;
        }

        if (blackboard.ActiveSelector == Selectors.FireSelector){
            TotalRuinHits = AttackSettings.Instance.FireRuinAmount;
        }

        RuinHits = 0;
        blackboard.ActivateElement(blackboard.ActiveSelector);
    }

    public override void OnExit()
    {
        HandTriggerDetector.Instance.OnTrigger -= OnTrigger;
        blackboard.DeActivateElement(blackboard.ActiveSelector);
    }

    private void OnTrigger(Selectors trigger){
        if (trigger == blackboard.ActiveSelector){
            RuinHits++;

            if (RuinHits >= TotalRuinHits){
                Shoot();
            }
        }
    }

    private void Shoot(){
        fsm.SwitchState(typeof(ElementShootState));
    }
}
