using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerPointOne : MonoBehaviour
{
    public GameObject DoorFace;
    public bool PointOneOpen;
    public GameObject ConfirmPoint;
    public float Timer;
    public float MaxTime;

    private void Awake()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            Timer += Time.deltaTime;
            ConfirmPoint.SetActive(true);

            if (Timer > MaxTime)
            {
                PointOneOpen = true;
            }
            //Debug.Log("trig");
           
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            PointOneOpen = false;
            ConfirmPoint.SetActive(false);
            Timer = 0;  
        }
    }

}
