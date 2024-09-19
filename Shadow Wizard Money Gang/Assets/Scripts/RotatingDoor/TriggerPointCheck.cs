using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPointCheck : MonoBehaviour
{
    public DoorTriggerPointOne Pt1;
    public DoorTriggerPointTwo Pt2;
    public DoorTriggerPointThree Pt3;
    //public GameObject Tp;
    public GameObject ShootTrgger1;
    public GameObject ShootTrgger2;
    public GameObject ShootTrgger3;
    public GameObject Key;
   /* public GameObject ConfetyCanon1;
    public GameObject ConfetyCanon2;
    public GameObject Pic1;
    public GameObject Pic2;
    public GameObject Pic3;
    public GameObject Pic4;
    public GameObject CatPic;
    public GameObject CatPic2;
    public GameObject CatPic3;*/
    void Update()
    {
        if (Pt1.PointOneOpen) 
        {
        if(Pt2.PointTwoOpen) 
            {
            if(Pt3.PointThreeOpen) 
                {
                    //Debug.Log("Open");
                    //Tp.SetActive(true);
                    ShootTrgger1.SetActive(false);
                    ShootTrgger2.SetActive(false);
                    ShootTrgger3.SetActive(false);
                    Key.SetActive(true);
                    /*ConfetyCanon1.SetActive(true);
                    ConfetyCanon2.SetActive(true);
                    Pic1.SetActive(true);
                    Pic2.SetActive(true);
                    Pic3.SetActive(true);
                    Pic4.SetActive(true);
                    CatPic.SetActive(false);
                    CatPic2.SetActive(false);
                    CatPic3 .SetActive(false);*/
                }
            }
        }
    }
}
