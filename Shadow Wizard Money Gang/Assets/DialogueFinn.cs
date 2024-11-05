using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueFinn : MonoBehaviour
{
    private Controls playerInput;
    public GameObject[] DialogueText;
    public int textCount = 0;
    private FirstPersonControls controls;
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
        DialogueText[textCount].SetActive(false);
        DialogueText[textCount +1].SetActive(true);
        textCount += 1;

        if (textCount ==7)
        {
            controls.CanInteract = true;
            controls.moveSpeed = 0;
            controls.lookSpeed = 0;
            controls.canCrouch = false;
            controls.canMeow = false;
            controls.jumpHeight = 0;
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        dialogueTutText.SetActive(true);
    }
}

