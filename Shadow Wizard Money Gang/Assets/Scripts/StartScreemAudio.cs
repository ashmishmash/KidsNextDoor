using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreemAudio : MonoBehaviour
{
    [Header("Start Screen Background Mucsic")]
    public AudioSource startScreenSource;
    public GameObject startAudio;
    public bool StartScreenPlaying;

    [Header("Options screen Background Mucsic")]
    public AudioSource OptionsScreenSource;
    public GameObject OptionsAudio;
    public bool OptionsScreenPlaying;


    private void Start()
    {
        //startScreenSource.Play();
        startAudio.SetActive(true);
        StartScreenPlaying = true;
    }

    private void Update()
    {
       if (StartScreenPlaying == true) 
        {
            startAudio.SetActive(true);
            OptionsAudio.SetActive(false);
        }

       else 
        {
            startAudio.SetActive (false);
            OptionsAudio.SetActive(true);
        }
    }


    /*public IEnumerator stopStartScreenMusic() 
    {
        //startScreenSource.Stop();
        startAudio.SetActive (false);
        yield return new WaitForSeconds(1);
        //OptionsScreenSource.Play();
        OptionsAudio.SetActive (true);
        OptionsScreenPlaying = true;
    }

    public IEnumerator stopOptionsScreenMusic()
    {
        OptionsAudio.SetActive (false);
        OptionsScreenPlaying = false;
        yield return new WaitForSeconds(1);
        startAudio.SetActive (true);
        StartScreenPlaying = true;
    }*/



}
