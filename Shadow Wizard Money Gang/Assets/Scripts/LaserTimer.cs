using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTimer : MonoBehaviour
{
   public FirstPersonControls FirstPersonControls;
    public GameObject Laser;
    public GameObject LaserImage1;
    public GameObject LaserImage2;
    public GameObject LaserImage3;

    private void Update()
    {
       if (FirstPersonControls.shooting == true) 
        {
            //Debug.Log("Shooting");
            StartCoroutine(Timer());
        }

       if(FirstPersonControls.shooting == false) 
        {
        StopCoroutine(Timer());
        }
    }


    public IEnumerator Timer() 
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
       
    }
}
