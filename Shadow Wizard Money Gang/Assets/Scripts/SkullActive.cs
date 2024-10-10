using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullActive : MonoBehaviour
{
    public GameObject key;
    public GameObject image;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            Debug.Log("key unlock");
            key.SetActive(true);
        }
    }
}
