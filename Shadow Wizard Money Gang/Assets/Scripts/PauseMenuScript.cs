using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [Header("Animators")]
    [Space(5)]
    public Animator tscrollAnim;
    public Animator bscrollAnim;
    public Animator pageAnim;
    public Animator pawsAnim;


    [Header("Pause menu stuff")]
    [Space(5)]
    public int inputCount;
    public bool isPaused = false;
    public GameObject pauseImage;
    public CharacterController characterController;
    public FirstPersonControls controls;
    public ButtonControls buttonControls;

    [Header("Pause Buttons")]
    [Space(5)]
    public GameObject soundOptionsButtons;
    public GameObject quitButton;
    public GameObject goBackButton;
    public GameObject closeButton;
    

    [Header("Sound Options Menu")]
    [Space(5)]
    public GameObject musicSlider;
    public GameObject sfxToggle;

    [Header("Quit Menu")]
    [Space(5)]
    public GameObject yesQuitButton;

    [Header("Variables")]
    [Space(5)]
    public string lastPage = "Pause";

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
            //tscrollAnim.SetFloat("Speed", 1f);
            //tscrollAnim.enabled = true;

            pageAnim.SetFloat("Speed", 1f);
            pageAnim.enabled = true;
            pageAnim.Play("page open");

            bscrollAnim.SetFloat("Speed", 1f);
            bscrollAnim.enabled = true;


            pawsAnim.SetFloat("Speed", 1f);
            pawsAnim.enabled = true;

            DisableControls();


            Time.timeScale = 0;

            StartCoroutine(WaitForAnim());
            

        } 
        else if (isPaused)
        {
            buttonControls.Resume();
            isPaused = false;
        }

        
    }

    public IEnumerator WaitForAnim()
    {
        yield return new WaitForSecondsRealtime(2f);
        soundOptionsButtons.SetActive(true);
        quitButton.SetActive(true);
        closeButton.SetActive(true);

        pawsAnim.enabled = false;
        pageAnim.enabled = false;
       // tscrollAnim.enabled = false;
        bscrollAnim.enabled = false; 
    }

    public IEnumerator WaitForCloseButton()
    {
        closeButton.SetActive(false);
        yield return new WaitForSecondsRealtime(2f);
        closeButton.SetActive(true);
      
    }

    public IEnumerator WaitToDisable()
    {
        yield return new WaitForSecondsRealtime(0.2f);


        musicSlider.SetActive(false);
        sfxToggle.SetActive(false);

        yesQuitButton.SetActive(false);
        goBackButton.SetActive(false);
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

    public void SoundOptionsMenu()
    {
        lastPage = "Sound";
        soundOptionsButtons.SetActive(false);

        StartCoroutine(WaitForCloseButton());

        pageAnim.SetBool("isSound", true);
        pageAnim.enabled = true;
        pageAnim.Play("page sound");
        
        StartCoroutine(WaitForSoundOptions());
}

    public IEnumerator WaitForSoundOptions()
    {
        yield return new WaitForSecondsRealtime(1f);
        musicSlider.SetActive(true);
        sfxToggle.SetActive(true);
        goBackButton.SetActive(true);
        pageAnim.enabled = false;
    }

    public void QuitMenu()
    {
        lastPage = "Quit";
        quitButton.SetActive(false);

        StartCoroutine(WaitForCloseButton());
        
        pageAnim.SetBool("isQuit", true);
        pageAnim.SetFloat("Speed", 1f);
        pageAnim.enabled = true;
        pageAnim.Play("page quit");
        
        StartCoroutine(WaitforQuitMenu());
    }

    public IEnumerator WaitforQuitMenu()
    {
        yield return new WaitForSecondsRealtime(3f);
        yesQuitButton.SetActive(true);
        goBackButton.SetActive(true);
        pageAnim.enabled = false;
    }

    public void GoBack()
    {
        StartCoroutine(WaitForCloseButton());
        
        if (lastPage == "Sound")
        {
            pageAnim.SetFloat("Speed", 1f);
            pageAnim.enabled = true;
            pageAnim.Play("back from sound");
            lastPage = "Pause";
        }
        else if (lastPage == "Quit")
        {
            pageAnim.SetFloat("Speed", 1f);
            pageAnim.enabled = true;
            pageAnim.Play("back from quit");
            lastPage = "Pause";
        }
        
        StartCoroutine(WaitForAnim());
        StartCoroutine(WaitToDisable());
    }
}
