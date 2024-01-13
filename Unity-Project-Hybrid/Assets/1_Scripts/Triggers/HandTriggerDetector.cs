using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandTriggerDetector : MonoBehaviour
{
    public static HandTriggerDetector Instance { get; private set; }

    public event Action<RuinTrigger> OnTrigger;

    public void Awake(){
        Instance = this;
    }

    public void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Trigger") && OnTrigger != null){
            RuinTrigger trigger = other.gameObject.GetComponent<RuinTrigger>();

            if (trigger == null) { Debug.LogError(trigger.name + " Is missing the trigger script"); }

            OnTrigger(trigger);
        }
    }
}
