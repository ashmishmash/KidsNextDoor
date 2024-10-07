using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{ 
    public Animator tscrollAnim;
    public Animator bscrollAnim;
    public Animator pageAnim;
    public Animator pawsAnim;


    public int inputCount;
    public GameObject pauseImage;
    //public FirstPersonControls firstPersonControls
    public CharacterController characterController;

    public FirstPersonControls controls;

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

   
    public void Pause()
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
        tscrollAnim.enabled = true;
        tscrollAnim.Play("top scroll");
        bscrollAnim.enabled = true;
        bscrollAnim.Play("bottom scroll open");
        pageAnim.enabled = true;
        pageAnim.Play("page");
        pawsAnim.enabled = true;
        pawsAnim.Play("paws");
        //firstPersonControls.enabled = false;
        characterController.enabled = false;
        controls.lookSpeed = 0;
        Time.timeScale = 0;
        
        //firstPersonControls.canShoot = false;
    }
}
