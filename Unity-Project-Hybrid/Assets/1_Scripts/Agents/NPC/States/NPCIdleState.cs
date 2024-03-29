using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleState : BaseState<NPCBlackboard>
{
    private float timer;

    public override void OnStart()
    {
        timer = Random.Range(GameSettings.Instance.AgentMinIdleTime, GameSettings.Instance.AgentMaxIdleTime);
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0){
            fsm.SwitchState(typeof(NPCWalkState));
        }
    }
}