using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandTriggerDetector : MonoBehaviour
{
    public static HandTriggerDetector Instance { get; private set; }

    public event Action OnWaterElementSelector;

    public void Awake(){
        Instance = this;
    }

    public void OnTriggerEnter(Collider other){

        if (other.gameObject.layer == LayerMask.NameToLayer("WaterElementSelector") && OnWaterElementSelector != null){
            OnWaterElementSelector();
        }
    }
}
