using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueFinn : MonoBehaviour
{
    private Controls playerInput;
    public GameObject[] DialogueText;
    public int textCount = 0;
    public FirstPersonControls controls;
    public GameObject dialogueTutText;
    public void StartDialogue()
    {
        // Create a new instance of the input actions
        playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the movement input events
        playerInput.Player.Dialogue.performed += ctx => Dialogue();


    }
    public void Dialogue()
    {
        if (textCount < 6)
        {
            DialogueText[textCount].SetActive(false);
            DialogueText[textCount + 1].SetActive(true);
            textCount += 1;
            Debug.Log(textCount);
        }
        else
        {
            DialogueText[textCount].SetActive(false);
            controls.CanInteract = true;
            controls.currentSpeed = 3f;
            controls.lookSpeed = 0.25f;
            controls.canCrouch = true;
            controls.canMeow = true;
            controls.jumpHeight = 1f;
            textCount = 0;
        }

    }

    
}

