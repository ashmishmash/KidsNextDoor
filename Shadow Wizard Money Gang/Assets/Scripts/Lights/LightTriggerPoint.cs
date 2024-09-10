using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightTriggerPoint : MonoBehaviour
{
    public Light Light;
     float TimeToWait = 5f;
     float maxLight = 20f;
     float MidLight = 10f;
     float minLight = 5f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FlameOn());
        }
    }

   

    public IEnumerator FlameOn() 
    {
        Light.enabled = true;
        Light.intensity = maxLight;
        yield return new WaitForSeconds(TimeToWait);
        Light.intensity = MidLight;
        yield return new WaitForSeconds(TimeToWait);
        Light.intensity = minLight;
        yield return new WaitForSeconds(TimeToWait);
    }
    
}
