using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    private bool AttackActive;
    private float RTriggerHoldDelayTimer;
    private float RTriggerReleaseDelayTimer;
    private GameObject elementSelectorInstance;
    private GameObject waterSelectorInstance;

    public void Start(){
        InputManager.Instance.OnRIndexTrigger += OnRIndexTrigger;
        InputManager.Instance.OnRIndexTriggerLoose += OnRIndexTriggerLoose;

        HandTriggerDetector.Instance.OnWaterElementSelector += OnElementWaterSelector;

        elementSelectorInstance = Instantiate(AttackSettings.Instance.ElementSelector, Vector3.zero, Quaternion.identity);
        elementSelectorInstance.SetActive(false);

        waterSelectorInstance = Instantiate(AttackSettings.Instance.WaterSelector, Vector3.zero, quaternion.identity);
        waterSelectorInstance.SetActive(false);
    }

    private void OnRIndexTrigger(){
        
        RTriggerReleaseDelayTimer = AttackSettings.Instance.TriggerDelay;
        
        RTriggerHoldDelayTimer -= Time.deltaTime;

        if (RTriggerHoldDelayTimer <= 0 && !AttackActive){
            AttackActive = true;
            elementSelectorInstance.SetActive(true);
            SetObjectInFrontOfPlayer(elementSelectorInstance);
        }
    }

    private void OnRIndexTriggerLoose(){

        RTriggerHoldDelayTimer = AttackSettings.Instance.TriggerDelay;

        RTriggerReleaseDelayTimer -= Time.deltaTime;

        if (RTriggerReleaseDelayTimer <= 0 && AttackActive){
            AttackActive = false;
            DisableElementSelector();
            waterSelectorInstance.SetActive(false);
        }
    }

    private void OnElementWaterSelector(){
        DisableElementSelector();
        waterSelectorInstance.SetActive(true);
        SetObjectInFrontOfPlayer(waterSelectorInstance);
    }

    private void SetObjectInFrontOfPlayer(GameObject currentObject){
        currentObject.transform.position = GetAttackPos();
        currentObject.transform.LookAt(Camera.main.transform);
        currentObject.transform.eulerAngles = new Vector3(0, currentObject.transform.eulerAngles.y, currentObject.transform.eulerAngles.z);
    }

    private void DisableElementSelector(){
        elementSelectorInstance.SetActive(false);
    }

    private Vector3 GetAttackPos(){
        return Camera.main.transform.position + Camera.main.transform.forward * AttackSettings.Instance.ElementSelectorDistanceFromCam;
    }
}
