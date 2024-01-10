using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSettings", menuName = "ScriptableObjects/AttackSettings")]
public class AttackSettings : ScriptableObject
{
    public static AttackSettings Instance { 
        get{
            if (instance == null){
                instance = Resources.Load<AttackSettings>("AttackSettings");

                if (instance == null) {Debug.Log("AttackSettings couln't be loaded...");}
            }

            return instance;
        }
    }
    private static AttackSettings instance;

    //[Header("Cooldowns")]
}
