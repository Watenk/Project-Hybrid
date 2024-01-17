using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinPattern : MonoBehaviour
{
    public List<GameObject> enabledRuins = new List<GameObject>();

    private List<GameObject> disabledRuins = new List<GameObject>();
    private int ruinCount;

    //--------------------------------------------------------

    public void Init(){

        ruinCount = enabledRuins.Count;
    }

    public void EnableAllRuins(){
        foreach (GameObject ruin in disabledRuins){
            enabledRuins.Add(ruin);
            ruin.SetActive(true);
        }

        disabledRuins.Clear();
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

    public int GetRuinCount(){
        return ruinCount;
    }
}
