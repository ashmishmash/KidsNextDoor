using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTimer : MonoBehaviour
{
   public FirstPersonControls FirstPersonControls;

    private void Update()
    {
       if (FirstPersonControls.shooting) 
        {
            Debug.Log("Shooting");
        }
    }
}
