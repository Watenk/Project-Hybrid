using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleState : BaseState
{
    private float timer;

    public override void OnStart()
    {
        timer = Random.Range(NPCSettings.Instance.MinIdleTime, NPCSettings.Instance.MaxIdleTime);
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0){
            fsm.SwitchState(typeof(NPCWalkState));
        }
    }
}