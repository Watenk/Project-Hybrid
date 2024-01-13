using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource MusicSource;
    public AudioSource SfxSource0;
    public AudioSource SfxSource1;

    public void Awake(){
        Instance = this;
    }

    public void PlaySound(AudioClip audioClip, SoundSource source){

        if (source == SoundSource.Music){
            if (!MusicSource.isPlaying){
                MusicSource.clip = audioClip;
                MusicSource.Play();
            }
            else{
                Debug.LogWarning("MusicSource Audio busy");
            }
        }

        if (source == SoundSource.SFX0){
            if (!SfxSource0.isPlaying){
                SfxSource0.clip = audioClip;
                SfxSource0.Play();
            }
            else{
                Debug.LogWarning("SfxSource0 Audio busy");
            }
        }

        if (source == SoundSource.SFX1){
            if (!SfxSource1.isPlaying){
                SfxSource1.clip = audioClip;
                SfxSource1.Play();
            }
            else{
                Debug.LogWarning("SfxSource1 Audio busy");
            }
        }
    }
}

public enum SoundSource{
    Music,
    SFX0,
    SFX1
}
