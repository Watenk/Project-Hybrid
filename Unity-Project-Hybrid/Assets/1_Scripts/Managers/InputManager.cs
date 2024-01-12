using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public event Action OnRIndexTrigger;
    public event Action OnRIndexTriggerLoose;

    public void Awake(){
        Instance = this;
    }

    public void Update(){
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
