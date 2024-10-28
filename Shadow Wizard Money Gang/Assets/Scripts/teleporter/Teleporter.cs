using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject player;
    public GameObject Tp2;
    public float xAzis;
    public float yAzis;
    public float zAzis;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController controller = player.GetComponent<CharacterController>();

        if (other.gameObject.CompareTag("Player"))
        {
          
                controller.enabled = false; // disable CharacterController to move the player
                player.transform.position = Tp2.transform.position;
                player.transform.eulerAngles = new Vector3(xAzis, yAzis, zAzis);
                controller.enabled = true;  // re-enable CharacterController
               
        }
    }
}

