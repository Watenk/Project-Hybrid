using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementChargeState : BaseState<AttackManager>
{
    private int currentRuinHits;
    private RuinManager currentRuins;
    private NatureAnimation natureAnimation;

    public override void OnStart()
    {
        HandTriggerDetector.Instance.OnTrigger += OnTrigger;

        if (blackboard.ActiveSelector == SelectorsEnum.NatureSelector){
            currentRuins = blackboard.GetSelector(SelectorsEnum.NatureSelector).GetComponent<RuinManager>();
            blackboard.ActivateProjectile(SelectorsEnum.NatureSelector);
        }

        if (blackboard.ActiveSelector == SelectorsEnum.WaterSelector){
            currentRuins = blackboard.GetSelector(SelectorsEnum.WaterSelector).GetComponent<RuinManager>();
            blackboard.ActivateProjectile(SelectorsEnum.WaterSelector);
        }

        if (blackboard.ActiveSelector == SelectorsEnum.FireSelector){
            currentRuins = blackboard.GetSelector(SelectorsEnum.FireSelector).GetComponent<RuinManager>();
            blackboard.ActivateProjectile(SelectorsEnum.FireSelector);
        }

        currentRuinHits = 0;
        currentRuins.EnableAllRuins();
        blackboard.ActivateElement(blackboard.ActiveSelector);
    }

    public override void OnExit()
    {
        HandTriggerDetector.Instance.OnTrigger -= OnTrigger;
        blackboard.DeActivateElement(blackboard.ActiveSelector);
    }

    private void OnTrigger(RuinTrigger trigger){

        if (trigger.TriggerEnum == blackboard.ActiveSelector){
            currentRuinHits++;
            trigger.Disable();

            if (currentRuinHits >= currentRuins.RuinCount){
                Shoot();
            }
        }
    }

    private void Shoot(){
        fsm.SwitchState(typeof(ElementShootState));
    }
}
