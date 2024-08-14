using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerPointTwo : MonoBehaviour
{
    public GameObject DoorFace;
    public bool PointTwoOpen;
    public GameObject ConfirmPoint;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            //Debug.Log("trig2");
            PointTwoOpen = true;
            ConfirmPoint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            PointTwoOpen = false;
            ConfirmPoint.SetActive(false);
        }
    }
}
