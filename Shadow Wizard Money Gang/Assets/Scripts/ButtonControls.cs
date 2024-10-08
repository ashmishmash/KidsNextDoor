using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControls : MonoBehaviour
{
    public PauseMenuScript PauseMenuScript;
    public FirstPersonControls FirstPersonControls;
    public GameObject pauseImage;
    public CharacterController characterController;
    public FirstPersonControls controls;

    public Animator tscrollAnim;
    public Animator bscrollAnim;
    public Animator pageAnim;
    public Animator pawsAnim;
    public void Resume() 
    {
        
       
        tscrollAnim.SetFloat("Speed",-1f);
        tscrollAnim.enabled = true;
        bscrollAnim.SetFloat("Speed", -1f);
        bscrollAnim.enabled = true;
        //bscrollAnim.Play("bottom scroll open");
        pageAnim.SetFloat("Speed", -1f);
        pageAnim.enabled = true;
        //pageAnim.Play("page");
        pawsAnim.SetFloat("Speed", -1f);
        pawsAnim.enabled = true;
        //pawsAnim.Play("paws");

        
        Debug.Log("Play");
        StartCoroutine(WaitToPlay());
       
    }

    public IEnumerator WaitToPlay()
    {  Debug.Log("Waiting");
        yield return new WaitForSecondsRealtime(2f);
        Debug.Log("Waited");
        tscrollAnim.enabled = false;
        bscrollAnim.enabled = false;
        pageAnim.enabled = false;
        pawsAnim.enabled = false;

        pauseImage.SetActive(false);
        PauseMenuScript.inputCount = 0;
        FirstPersonControls.enabled = true;
        characterController.enabled = true;
        controls.lookSpeed = 0.25f;
        Time.timeScale = 1;
        //FirstPersonControls.canShoot = true;

    }
}
