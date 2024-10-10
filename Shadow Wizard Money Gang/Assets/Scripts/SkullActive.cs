using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullActive : MonoBehaviour
{
    public GameObject key;
    public GameObject eye1;
    public GameObject eye2;
    public GameObject symbol;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            Debug.Log("key unlock");
            key.SetActive(true);
            eye1.SetActive(true);
            eye2.SetActive(true);

        }
    }
}
