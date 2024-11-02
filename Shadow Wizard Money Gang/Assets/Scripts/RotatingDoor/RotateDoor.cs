using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    public GameObject Zone;
    public GameObject DoorSound;
    public float roateDistance;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Laser")) 
        {
            //Debug.Log("Turn Door");
            Zone.transform.Rotate(0, 0, roateDistance);
            DoorSound.SetActive(true);
        }

     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Laser")) 
        {
            DoorSound.SetActive(false);
        }
    }

    
}
