using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinPatternShootState : BaseState<AttackManager>
{
    private IProjectile currentProjectile;
    private Elements currentElement;
    private float shootDelayTimer;

    public override void OnStart()
    {
        currentElement = blackboard.GetElement();
        currentProjectile = blackboard.GetProjectile(currentElement);
        shootDelayTimer = GameSettings.Instance.ShootDelay;
    }

    public override void OnUpdate()
    {
        if (shootDelayTimer <= 0){
            blackboard.SetProjectileRotation(currentElement ,GameManager.Instance.Hand.transform.rotation);
            currentProjectile.Shoot();
            fsm.SwitchState(typeof(RuinPatternIdleState));
        }
        else{
            shootDelayTimer -= Time.deltaTime;
        }
    }
}
