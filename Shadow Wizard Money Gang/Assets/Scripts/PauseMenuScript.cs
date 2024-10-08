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
    public FirstPersonControls firstPersonControls;
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

        tscrollAnim.SetFloat("Speed", 1f);
        tscrollAnim.enabled = true;

        bscrollAnim.SetFloat("Speed", 1f);
        bscrollAnim.enabled = true;

        pageAnim.SetFloat("Speed", 1f);
        pageAnim.enabled = true;

        pawsAnim.SetFloat("Speed", 1f);
        pawsAnim.enabled = true;
        
        firstPersonControls.enabled = false;
        characterController.enabled = false;
        controls.lookSpeed = 0;
        Time.timeScale = 0;

        StartCoroutine(WaitForAnim());
        //firstPersonControls.canShoot = false;
    }

    public IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(1f);
        pawsAnim.enabled = false;
        pageAnim.enabled = false;
        tscrollAnim.enabled = false;
        bscrollAnim.enabled = false;
    }
 
}
