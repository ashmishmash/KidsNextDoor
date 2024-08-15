using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPointCheck : MonoBehaviour
{
    public DoorTriggerPointOne Pt1;
    public DoorTriggerPointTwo Pt2;
    public DoorTriggerPointThree Pt3;
    public GameObject Tp;
    public GameObject ShootTrgger1;
    public GameObject ShootTrgger2;
    public GameObject ShootTrgger3;
    public GameObject ConfetyCanon1;
    public GameObject ConfetyCanon2;
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
                    ShootTrgger1.SetActive(false);
                    ShootTrgger2.SetActive(false);
                    ShootTrgger3.SetActive(false);
                    ConfetyCanon1.SetActive(true);
                    ConfetyCanon2.SetActive(true);
                }
            }
        }
    }
}
