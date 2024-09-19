using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject Laser;
    public GameObject Letter;
    public CharacterController characterController;
    public FirstPersonControls controls;

    void Start()
    {
        StartCoroutine(ShowLetter());
    }

   private IEnumerator ShowLetter()
    {
        characterController.enabled = false;
        controls.lookSpeed = 0f;
        yield return new WaitForSeconds(4f);
        characterController.enabled = true;
        controls.lookSpeed = 0.25f;
        controls.currentSpeed = 3f;
        Laser.SetActive(true);
        Letter.SetActive(false);
    }
}
