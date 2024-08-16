using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser")) 
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}
