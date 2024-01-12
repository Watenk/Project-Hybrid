using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public Selectors ActiveSelector = Selectors.None;
    
    private FSM<AttackManager> fsm;
    private Dictionary<Selectors, GameObject> selectors = new Dictionary<Selectors, GameObject>();

    public void Start(){
        InputManager.Instance.OnRIndexTrigger += OnRIndexTrigger;
        InputManager.Instance.OnRIndexTriggerLoose += OnRIndexTriggerLoose;

        AddSelector(Selectors.ElementSelector, AttackSettings.Instance.ElementSelector);
        AddSelector(Selectors.WaterSelector, AttackSettings.Instance.WaterSelector);
        AddSelector(Selectors.NatureSelector, AttackSettings.Instance.NatureSelector);
        AddSelector(Selectors.FireSelector, AttackSettings.Instance.FireSelector);

        fsm = new FSM<AttackManager>(this,
            new ElementIdleState(),
            new ElementSelectionState(),
            new ElementChargeState(),
            new ElementShootState()
        );
        fsm.SwitchState(typeof(ElementIdleState));
    }

    public void ActivateElement(Selectors selector){

        selectors.TryGetValue(selector, out GameObject currentElement);
        currentElement.SetActive(true);
        SetObjectInFrontOfPlayer(currentElement);
        ActiveSelector = selector;
    }

    public void DeActivateElement(Selectors selector){

        if (ActiveSelector != Selectors.None){
            selectors.TryGetValue(selector, out GameObject currentElement);
            currentElement.SetActive(false);

            if (selector != Selectors.ElementSelector){
                ActiveSelector = Selectors.None;
            }
        }
        else{
            Debug.LogError("Tried to deactivate element: " + name + " while none are active");
        }
    }

    private void SetObjectInFrontOfPlayer(GameObject currentObject){
        currentObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * AttackSettings.Instance.ElementSelectorDistanceFromCam;
        currentObject.transform.LookAt(Camera.main.transform);
        currentObject.transform.eulerAngles = new Vector3(0, currentObject.transform.eulerAngles.y, currentObject.transform.eulerAngles.z);
    }

    private void AddSelector(Selectors name, GameObject prefab){
        GameObject instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        instance.SetActive(false);
        selectors.Add(name, instance);
    }

    private void OnRIndexTrigger(){
        
        if (ActiveSelector == Selectors.None){
            fsm.SwitchState(typeof(ElementSelectionState));
        }
    }

    private void OnRIndexTriggerLoose(){

        if (ActiveSelector != Selectors.None){
            fsm.SwitchState(typeof(ElementIdleState));
        }
    }
}
