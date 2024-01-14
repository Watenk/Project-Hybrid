using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleState : BaseState<NPC>
{
    private float timer;

    public override void OnStart()
    {
        timer = Random.Range(GameSettings.Instance.MinIdleTime, GameSettings.Instance.MaxIdleTime);
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0){
            fsm.SwitchState(typeof(NPCWalkState));
        }
    }
}