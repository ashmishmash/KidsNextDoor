using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightTriggerPoint : MonoBehaviour
{
    public Light Light;
    public float TimeToWait;
    public float maxLight;
    public float MidLight;
    public float minLight;


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
