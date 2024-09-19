using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStuff : MonoBehaviour
{
    public FirstPersonControls firstPersonControls;
    public GameObject KeyToEnable;
    public GameObject DoorToOpen;

    // Start is called before the first frame update
   
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (firstPersonControls.keyCounter > 0))
        {
            firstPersonControls.keyCounter -= 1;
            KeyToEnable.SetActive(true); //enable key in door and wait a couple seconds
            StartCoroutine(OpenDoor()); //unlock door
        }
    }

    public IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(2f);
        DoorToOpen.SetActive(false);
    }



}
