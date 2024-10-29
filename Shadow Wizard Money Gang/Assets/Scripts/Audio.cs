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
    public bool canPlay;
    public AudioClip keys;
    public AudioClip Catsound;
    public bool SoundEffectPlay;

    [Header("Puzzle Sounds")]
    public AudioClip Correct;
    public AudioClip Incorrect;

    private void Awake()
    {
        //Backgroundsource.Play();
    }
    void Update()
    {
        

       /* if (SoundEffectPlay == true && canPlay == true) 
        {
            //SoundEffects.PlayOneShot(wind);
            Backgroundsource.PlayOneShot(keys);
        }   */    
    }

    
}
