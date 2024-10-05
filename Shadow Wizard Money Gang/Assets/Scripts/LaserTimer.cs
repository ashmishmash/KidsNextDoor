using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTimer : MonoBehaviour
{
    [Header("Other Scripts")]
    [Space(2)]
    public FirstPersonControls FirstPersonControls;
    public Timer timer;

    [Header("laser")]
    [Space(1)]

    public GameObject Laser;
    

    [Header("Power")]
    [Space(4)]
    public int LaserPower;
    public int MaxLaserPower;
    public int PowerSubtraction;
    public bool StablePowerLevel;

  

    [Header("Images")]
    [Space(3)]

    public GameObject LaserImage1;
    public GameObject LaserImage2;
    public GameObject LaserImage3;

    private IEnumerator MyCo;

    private void Awake()
    {
        //MyCo = PowerBack();
        StablePowerLevel = true;
    }

    private void FixedUpdate()
    {
        if (FirstPersonControls.isLaserOn)
        {
            //Debug.Log("Laser On");
            LaserPower -= PowerSubtraction;
        }

        if (LaserPower == 150)
        {
            LaserImage1.SetActive(false);
        }

        if (LaserPower == 70)
        {
            LaserImage2.SetActive(false);
        }

        if (LaserPower == 0)
        {
            LaserImage3.SetActive(false);
        }


        if (LaserPower == 0)
        {
            PowerSubtraction = 0;
            FirstPersonControls.canShoot = false;
            FirstPersonControls.isLaserOn = false;
            FirstPersonControls.shooting = false;
            Laser.SetActive(false);
            StablePowerLevel = false;
            timer.enabled = true;
        }



        if (LaserPower == MaxLaserPower)
        {
            LaserImage1.SetActive(true);
            LaserImage2.SetActive(true);
            LaserImage3.SetActive(true);
            //StablePowerLevel = true;
        }

        

    }


    /*public IEnumerator Timer() 
    {
        
        {
            yield return new WaitForSeconds(4f);
            LaserImage1.SetActive(false);
            yield return new WaitForSeconds(3f);
            LaserImage2.SetActive(false);
            yield return new WaitForSeconds(2f);
            LaserImage3.SetActive(false);
            FirstPersonControls.canShoot = false;
            FirstPersonControls.isLaserOn = false;
            FirstPersonControls.shooting = false;
            Laser.SetActive(false);
            yield return new WaitForSeconds(3f);
            FirstPersonControls.canShoot = true;
            LaserImage1.SetActive(true);
            LaserImage2.SetActive(true);
            LaserImage3.SetActive(true);
            StopCoroutine(Timer());
        }
       
    }*/

    public IEnumerator PowerBack() 
    {
            //Debug.Log("p");
            yield return new WaitForSeconds(5f);
            FirstPersonControls.canShoot = true;
            PowerSubtraction = 1;
            yield return new WaitForSeconds(0);
            LaserPower = MaxLaserPower;
            StablePowerLevel = true; 
    }
}
