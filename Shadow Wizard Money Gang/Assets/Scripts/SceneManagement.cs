using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Animator tscrollAnim;
    public Animator bscrollAnim;
    public Animator pageAnim;
    public Animator pawsAnim;

    public Animator doorAnimator;
    public Animator cameraAnimator;
    public GameObject OptionsMenu;

    public GameObject startbutton;
    public GameObject quitbutton;
    public GameObject optionbutton;

    public StartScreemAudio StartScreemAudio;

    public void StartGame()
    {
        Debug.Log("start");


        //play door animation
        doorAnimator.enabled = true;
        startbutton.SetActive(false);
        quitbutton.SetActive(false);
        optionbutton.SetActive(false);
        cameraAnimator.SetBool("isStart", true);
        //wait a few seconds
        StartCoroutine(WaitDoor());

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        //open options panel
        OptionsMenu.SetActive(true);

        bscrollAnim.SetFloat("Speed", 1f);
        bscrollAnim.enabled = true;

        pageAnim.SetFloat("Speed", 1f);
        pageAnim.enabled = true;
        StartScreemAudio.StartScreenPlaying = false;

    }

  
    public IEnumerator WaitDoor()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(1);
    }

    public void CloseOptions()
    {
        //close options panel
        OptionsMenu.SetActive(false);
        StartScreemAudio.StartScreenPlaying = true;
    }

    

    
}
