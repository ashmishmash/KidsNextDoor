using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    private void Awake()
    {
        // Get and store the CharacterController component attached to this GameObject
        
    }

    private void OnEnable()
    {
        // Create a new instance of the input actions
        var playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();

        playerInput.Player.Pause.performed += ctx => Pause();

    }


   

    public int inputCount;
    public GameObject pauseImage;
    //public FirstPersonControls firstPersonControls
    public CharacterController characterController;
    

    private void Pause()
    {
        inputCount++;
        //Debug.Log(inputCount);

        /*if (inputCount == 1)
        {
            pauseImage.SetActive(true);
            firstPersonControls.enabled = false;
            Time.timeScale = 0;
            firstPersonControls.canShoot = false;

        }

        if (inputCount == 2)
        {
            pauseImage.SetActive(false);
            firstPersonControls.enabled=true;
            Time.timeScale = 1;
            firstPersonControls.canShoot = true;
            inputCount = 0;
        }*/

        pauseImage.SetActive(true);
        //firstPersonControls.enabled = false;
        characterController.enabled = false;
        Time.timeScale = 0;
        //firstPersonControls.canShoot = false;
    }
}
