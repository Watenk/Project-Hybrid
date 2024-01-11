using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementChargeState : BaseState<AttackManager>
{
    public override void OnStart()
    {
        blackboard.ActivateElement(blackboard.ActiveElement);
    }
}
