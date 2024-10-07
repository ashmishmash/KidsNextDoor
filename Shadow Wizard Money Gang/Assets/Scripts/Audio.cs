using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [Header("Source")]
    public AudioSource Backgroundsource;
    public AudioSource SoundEffects;
   

    [Header("Background Music")]
    public AudioClip DungenMusic;

    [Header("sound effects")]
    public AudioClip wind;
    public bool SoundEffectPlay;

    private void Awake()
    {
        Backgroundsource.Play();
    }
    void Update()
    {
        

        if (SoundEffectPlay == true) 
        {
            SoundEffects.PlayOneShot(wind);
        }       
    }

    
}
