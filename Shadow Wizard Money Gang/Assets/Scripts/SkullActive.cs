using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullActive : MonoBehaviour
{
    public GameObject key;
    public GameObject eye1;
    public GameObject eye2;
    public GameObject symbol;
    public GameObject SkullSound;
    public bool laserEyeOff;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            Debug.Log("key unlock");
            key.SetActive(true);
           
            eye1.SetActive(true);
            eye2.SetActive(true);
            SkullSound.SetActive(true);
            symbol.SetActive(true);
        }
    }

    private void Update()
    {
     if(laserEyeOff == true) 
        {
            //Debug.Log("laser eye off");
            eye1.SetActive(false);
            eye2.SetActive(false);
            laserEyeOff = false;
        }   
    }
}
