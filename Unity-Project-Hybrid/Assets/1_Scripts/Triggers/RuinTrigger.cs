using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RuinTrigger : MonoBehaviour
{
    public SelectorsEnum TriggerEnum;

    private RuinManager ruinManager;

    public void Start(){
        ruinManager = transform.parent.GetComponent<RuinManager>();
    }

    public void Disable(){
        ruinManager.DisableRuin(this);
    }
}
