using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PressAnything : MonoBehaviour
{
    private Controls playerInput;
    public GameObject StartButton;
    public GameObject QuitButton;
    public GameObject OptionButton;
    public Animator anim;
    private void Start()
    {
        // Create a new instance of the input actions
         playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the movement input events
        playerInput.Player.Startgame.performed += ctx => StartGame();

        
    }

   

    void StartGame()
    {
        //play anim
        anim.SetBool("isPressed", true);


        StartCoroutine(Wait());

        //enable buttons
        

        playerInput.Player.Disable();
        playerInput.Player.Startgame.performed -= ctx => StartGame();
    }

    private  IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.7f);
        
        StartButton.SetActive(true);
        QuitButton.SetActive(true);
        OptionButton.SetActive(true);
    }
}

