using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInstructions : MonoBehaviour
{
    public GameObject interactText;
    public GameObject Key;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            {
            //Debug.Log("pickUp");
            interactText.SetActive(true);
            }
    }

    private void OnTriggerExit(Collider other)
    {
        interactText.SetActive(false);
    }

    private void Update()
    {
        if(Key == null) 
        {
        interactText.SetActive(false);
        }
    }
}
