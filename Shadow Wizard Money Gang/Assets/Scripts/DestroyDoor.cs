using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    public GameObject pic;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser")) 
        {
        Destroy(this.gameObject);
        Destroy(pic);
        }
    }
}
