using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandTriggerDetector : MonoBehaviour
{
    public static HandTriggerDetector Instance { get; private set; }

    public event Action OnWaterElementSelector;
    public event Action OnNatureElementSelector;
    public event Action OnFireElementSelector;
    public event Action OnReachedEnd;

    public void Awake(){
        Instance = this;
    }

    public void OnTriggerEnter(Collider other){

        if (other.gameObject.layer == LayerMask.NameToLayer("WaterElementSelector") && OnWaterElementSelector != null){
            OnWaterElementSelector();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("NatureElementSelector") && OnNatureElementSelector != null){
            OnWaterElementSelector();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("FireElementSelector") && OnFireElementSelector != null){
            OnWaterElementSelector();
        }
    }
}
