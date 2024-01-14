using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : IUpdateable
{
    public event Action OnRIndexTrigger;
    public event Action OnRIndexTriggerLoose;

    public void OnUpdate()
    {
        if (CheckRIndexTriggerDown()) { 
            OnRIndexTrigger(); 
        }
        else{
            OnRIndexTriggerLoose();
        }
    }

    private bool CheckRIndexTriggerDown(){
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OnRIndexTrigger != null){
            return true;
        }
        return false;
    }
}
