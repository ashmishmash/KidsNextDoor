using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Other Scripts")]
    [Space(3)]
    public LaserTimer laserTime;
    public Timer tim;
    public FirstPersonControls FirstPersonControls;

    [Header("timer")]
    [Space(2)]
    public float timer;
    public float Maxtime;

    private void FixedUpdate()
    {
        if(laserTime.StablePowerLevel == false) 
        {
            timer += Time.deltaTime;
            if(timer > Maxtime) 
            {
                //laserTime.StablePowerLevel = true;
                
                FirstPersonControls.canShoot = true;
                laserTime.PowerSubtraction = 1;
                laserTime.StablePowerLevel = true;
                laserTime.LaserPower = laserTime.MaxLaserPower;
                timer = 0;
                tim.enabled = false;
           
            }
        }
    }
}
