using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementChargeState : BaseState<AttackManager>
{
    public override void OnStart()
    {
        Debug.LogError(blackboard.ActiveElement);
        blackboard.ActivateElement(blackboard.ActiveElement);
    }
}
