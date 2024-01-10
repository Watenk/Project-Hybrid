using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger)){
            Debug.Log("Jaaaa");
        }
    }
}
