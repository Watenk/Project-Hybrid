using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Selectors TriggerEnum;

    public void Destroy(){
        Destroy(this);
    }
}
