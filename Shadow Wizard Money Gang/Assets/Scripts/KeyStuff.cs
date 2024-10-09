using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStuff : MonoBehaviour
{
    public FirstPersonControls firstPersonControls;
    public GameObject KeyToEnable;
    public GameObject DoorToOpen;
    public int KeyNumber;
    public bool isdooropen = false;

    public Animator dungeonDoorAnim;
    // Start is called before the first frame update
   
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (firstPersonControls.keyCounter >= KeyNumber))
        {
            //firstPersonControls.keyCounter -= 1;
            KeyToEnable.SetActive(true); //enable key in door and wait a couple seconds
            isdooropen = true;
            StartCoroutine(OpenDoor()); //unlock door
        }
    }

    public IEnumerator OpenDoor()
    {
        //play unlock sound

        yield return new WaitForSeconds(1f); //wait
        if (isdooropen == true)
        {
            dungeonDoorAnim.enabled = true; //play door anim
        }
        //DoorToOpen.SetActive(false);
    }



}
