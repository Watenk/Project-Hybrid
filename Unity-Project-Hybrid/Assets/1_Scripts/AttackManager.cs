using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    private bool AttackActive;
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
        
    }

    private void OnRIndexTriggerLoose(){

    }

    private void OnElementWaterSelector(){

    }

    private void SetObjectInFrontOfPlayer(GameObject currentObject){
        currentObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * AttackSettings.Instance.ElementSelectorDistanceFromCam;
        currentObject.transform.LookAt(Camera.main.transform);
        currentObject.transform.eulerAngles = new Vector3(0, currentObject.transform.eulerAngles.y, currentObject.transform.eulerAngles.z);
    }
}
