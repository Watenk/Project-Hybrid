using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public string ActiveElement = "None";
    
    private FSM<AttackManager> fsm;
    private Dictionary<string, GameObject> elements = new Dictionary<string, GameObject>();
    private bool AttackActive;


    public void Start(){
        InputManager.Instance.OnRIndexTrigger += OnRIndexTrigger;
        InputManager.Instance.OnRIndexTriggerLoose += OnRIndexTriggerLoose;

        AddElement("Selector", AttackSettings.Instance.ElementSelector);
        AddElement("Water", AttackSettings.Instance.WaterSelector);
        AddElement("Nature", AttackSettings.Instance.NatureSelector);
        AddElement("Fire", AttackSettings.Instance.FireSelector);

        fsm = new FSM<AttackManager>(this,
            new ElementSelectionState()
        );
        fsm.SwitchState(typeof(ElementSelectionState));
    }

    public void ActivateElement(string name){

        if (ActiveElement == "None"){
            elements.TryGetValue(name, out GameObject currentElement);
            currentElement.SetActive(true);
            SetObjectInFrontOfPlayer(currentElement);
            ActiveElement = name;
        }
        else{
            Debug.LogError("Tried to activate element: " + name + " While " + ActiveElement + " is still active");
        }
    }

    public void DeActivateElement(string name){

        if (ActiveElement != "None"){
            elements.TryGetValue(name, out GameObject currentElement);
            currentElement.SetActive(false);

            if (name != "Selector"){
                ActiveElement = "None";
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

    private void AddElement(string name, GameObject prefab){
        GameObject instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        instance.SetActive(false);
        elements.Add(name, instance);
    }

    private void OnRIndexTrigger(){
        
        if (!AttackActive){
            AttackActive = true;

            fsm.SwitchState(typeof(ElementSelectionState));
        }
    }

    private void OnRIndexTriggerLoose(){

        if (AttackActive){
            AttackActive = false;

            fsm.SwitchState(typeof(ElementIdleState));
        }
    }
}
