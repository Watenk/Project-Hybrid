using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinPattern : MonoBehaviour
{
    public Elements Element;

    private List<GameObject> disabledRuins = new List<GameObject>();
    private List<GameObject> enabledRuins = new List<GameObject>();

    //--------------------------------------------------------

    public void Start(){

        GameSettings.Instance.HandTriggerDetector.OnRuinTrigger += OnRuinTrigger;

        foreach (Transform child in transform)
        {
            enabledRuins.Add(child.gameObject);
        }
    }

    public void EnableAllRuins(){
        foreach (GameObject ruin in disabledRuins){
            EnableRuin(ruin);
        }
    }

    public void EnableRuin(GameObject ruin){
        disabledRuins.Remove(ruin);
        enabledRuins.Add(ruin);
        ruin.SetActive(true);
    }

    public void DisableRuin(GameObject ruin){
        enabledRuins.Remove(ruin);
        disabledRuins.Add(ruin);
        ruin.SetActive(false);
    }

    //---------------------------------------

    private void OnRuinTrigger(RuinTrigger ruin){
        if (ruin.element == Element){
            DisableRuin(ruin.gameObject);
        }
    }
}
