using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public SelectorsEnum ActiveSelector = SelectorsEnum.None;
    
    private FSM<AttackManager> fsm;
    private Dictionary<SelectorsEnum, GameObject> selectors = new Dictionary<SelectorsEnum, GameObject>();
    private Vector3 previousPlayerPos = Vector3.zero;

    public void Start(){
        InputManager.Instance.OnRIndexTrigger += OnRIndexTrigger;
        InputManager.Instance.OnRIndexTriggerLoose += OnRIndexTriggerLoose;

        AddSelector(SelectorsEnum.ElementSelector, AttackSettings.Instance.ElementSelector);
        AddSelector(SelectorsEnum.WaterSelector, AttackSettings.Instance.WaterSelector);
        AddSelector(SelectorsEnum.NatureSelector, AttackSettings.Instance.NatureSelector);
        AddSelector(SelectorsEnum.FireSelector, AttackSettings.Instance.FireSelector);

        fsm = new FSM<AttackManager>(this,
            new ElementIdleState(),
            new ElementSelectionState(),
            new ElementChargeState(),
            new ElementShootState()
        );
        fsm.SwitchState(typeof(ElementIdleState));
    }

    public void ActivateElement(SelectorsEnum selector){

        selectors.TryGetValue(selector, out GameObject currentElement);
        currentElement.SetActive(true);
        if (selector == SelectorsEnum.ElementSelector){
            SetObjectInFrontOfPlayer(currentElement, true);
        }
        else{
            SetObjectInFrontOfPlayer(currentElement, false);
        }
        ActiveSelector = selector;
    }

    public void DeActivateElement(SelectorsEnum selector){

        if (ActiveSelector != SelectorsEnum.None){
            selectors.TryGetValue(selector, out GameObject currentElement);
            currentElement.SetActive(false);
        }
        else{
            Debug.LogError("Tried to deactivate element: " + selector + " while none are active");
        }
    }

    public void ActivateProjectile(SelectorsEnum selector){

        selectors.TryGetValue(selector, out GameObject currentElement);
        currentElement.SetActive(true);
        if (selector == SelectorsEnum.ElementSelector){
            SetObjectInFrontOfPlayer(currentElement, true);
        }
        else{
            SetObjectInFrontOfPlayer(currentElement, false);
        }
        ActiveSelector = selector;
    }

    public GameObject GetSelector(SelectorsEnum selector){
        selectors.TryGetValue(selector, out GameObject currentElement);
        return currentElement;
    }

    private void SetObjectInFrontOfPlayer(GameObject currentObject, bool isElementSelector){

        if (isElementSelector){
            currentObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * AttackSettings.Instance.ElementSelectorDistanceFromCam;
            currentObject.transform.LookAt(Camera.main.transform);
            currentObject.transform.eulerAngles = new Vector3(0, currentObject.transform.eulerAngles.y, currentObject.transform.eulerAngles.z);
            previousPlayerPos = currentObject.transform.position;
        }
        else{
            currentObject.transform.position = previousPlayerPos;
            currentObject.transform.LookAt(Camera.main.transform);
            currentObject.transform.eulerAngles = new Vector3(0, currentObject.transform.eulerAngles.y, currentObject.transform.eulerAngles.z);
        }
    }

    private void AddSelector(SelectorsEnum name, GameObject prefab){
        GameObject instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        instance.SetActive(false);
        selectors.Add(name, instance);
    }

    private void OnRIndexTrigger(){
        
        if (ActiveSelector == SelectorsEnum.None){
            fsm.SwitchState(typeof(ElementSelectionState));
        }
    }

    private void OnRIndexTriggerLoose(){

        if (ActiveSelector != SelectorsEnum.None){
            fsm.SwitchState(typeof(ElementIdleState));
            ActiveSelector = SelectorsEnum.None;
        }
    }
}
