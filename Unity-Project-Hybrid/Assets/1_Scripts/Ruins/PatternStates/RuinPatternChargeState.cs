using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinPatternChargeState : BaseState<RuinPatternManager>
{
    private int currentRuinHits;
    private Elements currentElement;
    private RuinPattern currentRuinPattern;

    public override void OnStart()
    {
        blackboard.handTriggerDetector.OnRuinTrigger += OnRuinTrigger;

        currentRuinHits = 0;
        currentElement = blackboard.GetElement();
        currentRuinPattern = blackboard.GetRuinPattern(currentElement);
        blackboard.RuinPatternSetActive(currentElement, true);
    }

    public override void OnExit()
    {
        blackboard.handTriggerDetector.OnRuinTrigger += OnRuinTrigger;
        
        blackboard.RuinPatternSetActive(currentElement, false);
    }

    private void OnRuinTrigger(RuinTrigger ruinTrigger){

        currentRuinHits++;

        currentRuinPattern.DisableRuin(ruinTrigger.gameObject);

        if (currentRuinHits >= currentRuinPattern.GetRuinCount()){
            fsm.SwitchState(typeof(RuinPatternShootState));
        }
    }
}
