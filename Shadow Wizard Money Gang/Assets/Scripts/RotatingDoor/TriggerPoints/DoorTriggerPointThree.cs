using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerPointThree : MonoBehaviour
{
    public GameObject DoorFace;
    public bool PointThreeOpen;
    public GameObject ConfirmPoint;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            //Debug.Log("trig3");
            PointThreeOpen = true;
            ConfirmPoint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == DoorFace)
        {
            PointThreeOpen = false;
            ConfirmPoint.SetActive(false);
        }
    }
}
