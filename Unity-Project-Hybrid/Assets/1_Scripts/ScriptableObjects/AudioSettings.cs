using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "ScriptableObjects/AudioSettings")]
public class AudioSettings : ScriptableObject
{
    public static AudioSettings Instance { 
        get{
            if (instance == null){
                instance = Resources.Load<AudioSettings>("AudioSettings");

                if (instance == null) {Debug.Log("AudioSettings couln't be loaded...");}
            }

            return instance;
        }
    }
    private static AudioSettings instance;

    [Header("AudioClips")]
    public AudioClip music;
    public AudioClip FireImpact;
    public AudioClip FireProjectile;
    public AudioClip FireSummon;
    public AudioClip NatureImpact;
    public AudioClip NatureProjectile;
    public AudioClip NatureSummon;
    public AudioClip WaterImpact;
    public AudioClip WaterProjectile;
    public AudioClip WaterSummon;
}
