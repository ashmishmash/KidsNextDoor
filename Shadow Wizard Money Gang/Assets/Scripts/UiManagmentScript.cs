using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManagmentScript : MonoBehaviour
{
    public FirstPersonControls FirstPersonControls;
    public GameObject CrouchImage;
    public GameObject ShootImage;

    private void Update()
    {
        if (FirstPersonControls.isCrouching) 
        {
            //Debug.Log("Crouching");
            CrouchImage.SetActive(true);
        }

        if (FirstPersonControls.isCrouching == false) 
        {
        CrouchImage.SetActive(false);
        }

        /*if(FirstPersonControls.canShoot == true) 
        {
        ShootImage.SetActive(true);
        }

        if(FirstPersonControls.canShoot == false) 
        {
            ShootImage.SetActive(false);
        }*/
    }
}
