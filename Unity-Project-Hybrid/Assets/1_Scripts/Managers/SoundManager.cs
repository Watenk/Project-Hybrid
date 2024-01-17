using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundSource{
    Music,
    SFX0,
    SFX1
}

public class SoundManager
{
    private AudioSource musicSource;
    private AudioSource sfxSource0;
    private AudioSource sfxSource1;

    public SoundManager(AudioSource musicSource, AudioSource sfxSource0, AudioSource sfxSource1){
        this.musicSource = musicSource;
        this.sfxSource0 = sfxSource0;
        this.sfxSource1 = sfxSource1;
    }

    public void PlaySound(AudioClip audioClip, SoundSource source){

        if (source == SoundSource.Music){

            musicSource.clip = audioClip;
            musicSource.Play();
        }

        if (source == SoundSource.SFX0){

            sfxSource0.clip = audioClip;
            sfxSource0.Play();
        }

        if (source == SoundSource.SFX1){

            sfxSource1.clip = audioClip;
            sfxSource1.Play();
        }
    }
}
