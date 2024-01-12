using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandTriggerDetector : MonoBehaviour
{
    public static HandTriggerDetector Instance { get; private set; }

    public event Action<Selectors> OnTrigger;

    public void Awake(){
        Instance = this;
    }

    public void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Trigger") && OnTrigger != null){
            Trigger receiver = other.gameObject.GetComponent<Trigger>();
            OnTrigger(receiver.TriggerEnum);
        }
    }
}
