using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinPatternChargeState : BaseState<AttackManager>
{
    private int currentRuinHits;
    private Elements currentElement;
    private RuinPattern currentRuinPattern;
    private IProjectile currentProjectile;

    //---------------------------------------------------

    public override void OnStart(){
        blackboard.handTriggerDetector.OnRuinTrigger += OnRuinTrigger;

        currentProjectile = blackboard.GetProjectile(currentElement);
        currentRuinPattern = blackboard.GetRuinPattern(currentElement);
        currentElement = blackboard.GetElement();
        
        currentRuinHits = 0;
        blackboard.RuinPatternSetActive(currentElement, true);
        blackboard.ProjectileSetActive(currentElement, true);
        blackboard.SetProjectileRotation(currentElement ,GameManager.Instance.Player.transform.rotation);
        currentProjectile.Charge();
    }

    public override void OnExit(){
        blackboard.handTriggerDetector.OnRuinTrigger -= OnRuinTrigger;
        
        blackboard.RuinPatternSetActive(currentElement, false);
    }

    //----------------------------------------------------

    private void OnRuinTrigger(RuinTrigger ruinTrigger){

        currentRuinHits++;

        currentRuinPattern.DisableRuin(ruinTrigger.gameObject);

        Debug.LogError(ruinTrigger.gameObject.name + " is " + currentRuinHits + ", is: " + currentRuinPattern.GetRuinCount());

        if (currentRuinHits >= currentRuinPattern.GetRuinCount()){
            fsm.SwitchState(typeof(RuinPatternShootState));
        }
    }
}
