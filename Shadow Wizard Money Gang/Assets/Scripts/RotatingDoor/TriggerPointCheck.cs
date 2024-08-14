using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPointCheck : MonoBehaviour
{
    public DoorTriggerPointOne Pt1;
    public DoorTriggerPointTwo Pt2;
    public DoorTriggerPointThree Pt3;
    public GameObject Tp;
    void Update()
    {
        if (Pt1.PointOneOpen) 
        {
        if(Pt2.PointTwoOpen) 
            {
            if(Pt3.PointThreeOpen) 
                {
                    //Debug.Log("Open");
                    Tp.SetActive(true);
                }
            }
        }
    }
}
