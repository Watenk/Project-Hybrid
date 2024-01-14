using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinPatternSelectionState : BaseState<RuinPatternManager>
{
    public override void OnStart()
    {
        blackboard.handTriggerDetector.OnRuinTrigger += OnRuinTrigger;

        blackboard.RuinPatternSetActive(Elements.Selection, true);
    }
    
    public override void OnExit()
    {
        blackboard.handTriggerDetector.OnRuinTrigger -= OnRuinTrigger;

        blackboard.RuinPatternSetActive(Elements.Selection, false);
    }

    private void OnRuinTrigger(RuinTrigger ruinTrigger){

        blackboard.SetElement(ruinTrigger.element);
        fsm.SwitchState(typeof(RuinPatternChargeState));
    }
}
