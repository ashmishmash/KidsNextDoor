using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManagmentScript : MonoBehaviour
{
    public FirstPersonControls FirstPersonControls;
    public GameObject CrouchImage;

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
    }
}
