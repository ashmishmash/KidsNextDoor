using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControls : MonoBehaviour
{
    public PauseMenuScript PauseMenuScript;
    public FirstPersonControls FirstPersonControls;
    public GameObject pauseImage;

   public void Resume() 
    {
        Debug.Log("PLay");
        PauseMenuScript.inputCount = 0;
        FirstPersonControls.enabled = true;
        Time.timeScale = 1;
        FirstPersonControls.canShoot = true;
        pauseImage.SetActive(false);

    }
}
