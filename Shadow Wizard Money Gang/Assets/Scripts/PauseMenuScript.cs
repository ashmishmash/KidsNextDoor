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
    public bool isPaused = false;
    public GameObject pauseImage;
    public CharacterController characterController;

    public FirstPersonControls controls;
    public ButtonControls buttonControls;

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
        
        Debug.Log(inputCount);

        if (isPaused == false)
        {
            isPaused = true;
            pauseImage.SetActive(true);

            //image anims
            tscrollAnim.SetFloat("Speed", 1f);
            tscrollAnim.enabled = true;

            bscrollAnim.SetFloat("Speed", 1f);
            bscrollAnim.enabled = true;

            pageAnim.SetFloat("Speed", 1f);
            pageAnim.enabled = true;

            pawsAnim.SetFloat("Speed", 1f);
            pawsAnim.enabled = true;

            DisableControls();


            Time.timeScale = 0;

            StartCoroutine(WaitForAnim());
            

        } 
        else if (isPaused)
        {
            buttonControls.Resume();
            inputCount = 0;
            isPaused = false;
        }

        
    }

    public IEnumerator WaitForAnim()
    {
        yield return new WaitForSecondsRealtime(3f);
        pawsAnim.enabled = false;
        pageAnim.enabled = false;
        tscrollAnim.enabled = false;
        bscrollAnim.enabled = false;
    }
 
    public void DisableControls()
    {
        characterController.enabled = false;
        controls.lookSpeed = 0;
        controls.canShoot = false;
        controls.crouchSpeed = 0;
        controls.jumpHeight = 0;
        controls.canCrouch = false;
    }
}
