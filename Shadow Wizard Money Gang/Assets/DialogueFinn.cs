using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueFinn : MonoBehaviour
{
    private Controls playerInput;
    public GameObject[] DialogueText;
    public int textCount = 0;

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
        textCount += 1;
        DialogueText[textCount].SetActive(false);
        DialogueText[textCount +1].SetActive(true);

    }
}

