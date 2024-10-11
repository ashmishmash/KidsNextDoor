using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class SimplePause : MonoBehaviour
{
    [Header("Animators")]
    [Space(5)]
    public Animator bscrollAnim;
    public Animator pageAnim;
    public Animator pawsAnim;

    [Header("Pause menu stuff")]
    [Space(5)]
    public bool isPaused = false;
    public GameObject pauseImage;
    public CharacterController characterController;
    public FirstPersonControls controls;


    [Header("Pause Buttons")]
    [Space(5)]
    public GameObject quitButton;
    public GameObject closeButton;


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

        if (isPaused == false)
        {
            isPaused = true;
            pauseImage.SetActive(true);

            pageAnim.SetFloat("Speed", 1f);
            pageAnim.enabled = true;

            bscrollAnim.SetFloat("Speed", 1f);
            bscrollAnim.enabled = true;

            pawsAnim.SetFloat("Speed", 1f);
            pawsAnim.enabled = true;

            DisableController();


           // Time.timeScale = 0;

            StartCoroutine(WaitForAnim());


        }
        else if (isPaused)
        {
            Resume();
            isPaused = false;
        }
    }

    public IEnumerator WaitForAnim()
    {
        yield return new WaitForSecondsRealtime(2f);
        quitButton.SetActive(true);
        closeButton.SetActive(true);

        pawsAnim.enabled = false;
        pageAnim.enabled = false;
        bscrollAnim.enabled = false;
    }

    public void DisableController()
    {
        characterController.enabled = false;
        controls.lookSpeed = 0;
        controls.canShoot = false;
        controls.crouchSpeed = 0;
        controls.jumpHeight = 0;
        controls.canCrouch = false;
    }

    public void EnableController()
    {
        characterController.enabled = true;
        controls.lookSpeed = 0.25f;
        controls.canShoot = true;
        controls.crouchSpeed = 1.5f;
        controls.jumpHeight = 1f;
        controls.canCrouch = true;
    }

    public void Resume()
    {
        closeButton.SetActive(false);
        isPaused = false;

        pauseImage.SetActive(false);
        bscrollAnim.enabled = false;
        pageAnim.enabled = false;
        pawsAnim.enabled = false;
        EnableController();
    }

    public IEnumerator WaitToPlay()
    {
        yield return new WaitForSecondsRealtime(2f); 
        
        pauseImage.SetActive(false);
        bscrollAnim.enabled = false;
        pageAnim.enabled = false;
        pawsAnim.enabled = false;
        pageAnim.SetBool("isPaused", false);
        bscrollAnim.SetBool("isPaused", false);
        pawsAnim.SetBool("isPaused", false);

        EnableController();

       // Time.timeScale = 1;
    }

    public void CallQuit()
    {
        Application.Quit();
    }
}
