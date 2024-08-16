using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject player;
    public GameObject Tp2;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            CharacterController controller = player.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false; // disable CharacterController to move the player
                player.transform.position = Tp2.transform.position;
                controller.enabled = true;  // re-enable CharacterController
            }
            else
            {
                player.transform.position = Tp2.transform.position;
            }
        }
    }
}

