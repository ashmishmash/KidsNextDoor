using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;

    public Animator bscrollAnim;
    public Animator pageAnim;

    public GameObject closeButton;
    public GameObject soundOptionsButton;
    public GameObject controlsButton;
    public StartScreemAudio StartScreemAudio;

    public string lastPage = "Options";

    [Header("Options Menu")]
    [Space(5f)]
    public GameObject musicText;
    public GameObject sfxText;
    public GameObject OptionsText;
    public GameObject musicSlider;
    public GameObject sfxToggle;

    [Header("Controls Menu")]
    [Space(5f)]
    public GameObject controlsTitle;
    public GameObject controlsText;
    public void Options()
    {
        optionsMenu.SetActive(true);
        bscrollAnim.SetFloat("Speed", 1f);
        bscrollAnim.enabled = true;

        pageAnim.SetFloat("Speed", 1f);
        pageAnim.enabled = true;

        StartScreemAudio.StartScreenPlaying = false;
        StartCoroutine(WaitOptions());

    }

    public void Resume()
    {
        closeButton.SetActive(false);
        bscrollAnim.SetFloat("Speed", -1f);
        bscrollAnim.enabled = true; 
        pageAnim.SetFloat("Speed", 1f);
        pageAnim.enabled = true;
        pageAnim.Play("close from pause");

        StartScreemAudio.StartScreenPlaying = true;

        StartCoroutine(WaitToPlay());
    }
    public IEnumerator WaitToPlay()
    {

        yield return new WaitForSeconds(2f);


        bscrollAnim.enabled = false;
        pageAnim.enabled = false;


        optionsMenu.SetActive(false);
    }

    public void ControlsMenu()
    {
        closeButton.SetActive(false);
        lastPage = "Controls";
        
        pageAnim.SetFloat("Speed", 1f);
        pageAnim.enabled = true;
        pageAnim.Play("page quit");

        StartCoroutine(WaitControls());
    }

    public void SoundMenu()
    {
        closeButton.SetActive(false);
        lastPage = "Sound";

        pageAnim.enabled = true;
        pageAnim.Play("page sound");

        StartCoroutine(WaitSound());
    }

    public void GoBack()
    {
        closeButton.SetActive(false);
        if (lastPage == "Sound")
        {
            pageAnim.SetFloat("Speed", 1f);
            pageAnim.enabled = true;
            pageAnim.Play("back from sound");
            lastPage = "Options";
        }
        else if (lastPage == "Controls")
        {
            pageAnim.SetFloat("Speed", 1f);
            pageAnim.enabled = true;
            pageAnim.Play("back from quit");
            lastPage = "Options";
        }

        StartCoroutine(WaitForAnim());
        StartCoroutine(WaitToDisable());
    }

    public IEnumerator WaitOptions()
    {
        yield return new WaitForSeconds(2f);
        pageAnim.enabled = false;
        bscrollAnim.enabled = false;

        closeButton.SetActive(true);
        soundOptionsButton.SetActive(true);
        controlsButton.SetActive(true);
    }

    public IEnumerator WaitControls()
    {
        yield return new WaitForSeconds(2f);
        pageAnim.enabled = false;

        closeButton.SetActive( true);
        controlsText.SetActive(true);
        controlsTitle.SetActive(true);
    }

    public IEnumerator WaitSound()
    {
        yield return new WaitForSeconds(2f);
        pageAnim.enabled = false;

        closeButton.SetActive(true);
        musicSlider.SetActive(true);
        musicText.SetActive(true);
        sfxText.SetActive(true);
        sfxToggle.SetActive(true);
    }

    public IEnumerator WaitForAnim()
    {
        yield return new WaitForSecondsRealtime(2f);
        soundOptionsButton.SetActive(true);
        controlsButton.SetActive(true);
        closeButton.SetActive(true);

        // pawsAnim.enabled = false;
        pageAnim.enabled = false;
        // tscrollAnim.enabled = false;
        bscrollAnim.enabled = false;
    }

    public IEnumerator WaitToDisable()
    {
        yield return new WaitForSecondsRealtime(0.2f);


        musicSlider.SetActive(false);
        sfxToggle.SetActive(false);

        controlsText.SetActive(false);
        controlsTitle.SetActive(false);
        closeButton.SetActive(true);
    }
}
