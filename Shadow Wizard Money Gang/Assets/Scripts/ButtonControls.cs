using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControls : MonoBehaviour
{
    public PauseMenuScript PauseMenuScript;
    //public FirstPersonControls FirstPersonControls;
    public GameObject pauseImage;
    public CharacterController characterController;
    public FirstPersonControls controls;
   public void Resume() 
    {
        Debug.Log("PLay");
        PauseMenuScript.inputCount = 0;
        //FirstPersonControls.enabled = true;
        characterController.enabled = true;
        controls.lookSpeed = 0.25f;
        Time.timeScale = 1;
        //FirstPersonControls.canShoot = true;
        characterController.enabled = true;
        pauseImage.SetActive(false);

    }
}
