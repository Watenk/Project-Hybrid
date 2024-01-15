using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTriggerDetector : MonoBehaviour
{
    public event Action<RuinTrigger> OnRuinTrigger;

    public void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Trigger") && OnRuinTrigger != null){
            RuinTrigger ruinTrigger = other.gameObject.GetComponent<RuinTrigger>();
            if (ruinTrigger == null) { Debug.LogError(other.gameObject.name + " Doesn't contain a RuinTrigger"); }

            OnRuinTrigger(ruinTrigger);
        }
    }
}
