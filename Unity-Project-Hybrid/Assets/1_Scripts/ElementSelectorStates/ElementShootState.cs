using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementShootState : BaseState<AttackManager>
{
    public override void OnStart()
    {
        blackboard.DeActivateElement(blackboard.ActiveSelector);
        blackboard.ActiveSelector = SelectorsEnum.None;
    }
}
