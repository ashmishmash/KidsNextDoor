using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerPoint : MonoBehaviour
{
public Light Light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("light on");
            Light.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
