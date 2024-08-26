using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerPointThree : MonoBehaviour
{
    public GameObject DoorFace;
    public bool PointThreeOpen;
    public GameObject ConfirmPoint;
    public float Timer;
    public float MaxTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            Timer += Time.deltaTime;
            ConfirmPoint.SetActive(true);
            if (Timer > MaxTime)
            {
                PointThreeOpen = true;
            }
            //Debug.Log("trig3");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            PointThreeOpen = false;
            ConfirmPoint.SetActive(false);
            Timer = 0;  
        }
    }
}
