using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerPointTwo : MonoBehaviour
{
    public GameObject DoorFace;
    public bool PointTwoOpen;
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
                PointTwoOpen = true;
            }
            //Debug.Log("trig2");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            PointTwoOpen = false;
            ConfirmPoint.SetActive(false);
            Timer = 0;  
        }
    }
}
