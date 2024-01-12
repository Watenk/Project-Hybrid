using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinManager : MonoBehaviour
{
    public SelectorsEnum selector;
    public int RuinCount;

    private List<RuinTrigger> enabledTriggers = new List<RuinTrigger>();
    private List<RuinTrigger> disabledTriggers = new List<RuinTrigger>();

    public void Start(){
        RuinCount = transform.childCount;

        for (int i = 0; i < RuinCount; i++)
        {
            GameObject currentRuin = transform.GetChild(i).gameObject;
            RuinTrigger currentTrigger = currentRuin.GetComponent<RuinTrigger>();
            
            if (currentTrigger == null) { Debug.LogError(this.gameObject.name + " is missing the trigger script"); }

            enabledTriggers.Add(currentTrigger);
        }
    }

    public void DisableRuin(RuinTrigger trigger){
        
        foreach (RuinTrigger currentTrigger in enabledTriggers){
            if (trigger == currentTrigger){
                enabledTriggers.Remove(currentTrigger);
                disabledTriggers.Add(currentTrigger);
                currentTrigger.gameObject.SetActive(false);
                break;
            }
        }
    }

    public void EnableRuin(RuinTrigger trigger){
        
        foreach (RuinTrigger currentTrigger in disabledTriggers){
            if (trigger == currentTrigger){
                enabledTriggers.Add(currentTrigger);
                disabledTriggers.Remove(currentTrigger);
                currentTrigger.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void EnableAllRuins(){
        
        foreach (RuinTrigger currentTrigger in disabledTriggers){
            enabledTriggers.Add(currentTrigger);
            currentTrigger.gameObject.SetActive(true);
        }

        disabledTriggers.Clear();
    }
}
