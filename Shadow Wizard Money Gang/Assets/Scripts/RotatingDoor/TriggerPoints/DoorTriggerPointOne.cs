using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerPointOne : MonoBehaviour
{
    public GameObject DoorFace;
    public bool PointOneOpen;
    public GameObject ConfirmPoint;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            //Debug.Log("trig");
            PointOneOpen = true;
            ConfirmPoint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            PointOneOpen = false;
            ConfirmPoint.SetActive(false);
        }
    }

}
