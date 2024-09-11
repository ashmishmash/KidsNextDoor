using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameOn : MonoBehaviour
{
    public Light Light;
    public GameObject fire;
    public LightTriggerPoint LightTriggerPoint;
    public GameObject Trigger;
    float TimeToWait = 5f;
    float maxLight = 20f;
    float MidLight = 10f;
    float minLight = 5f;


    private void OnTriggerEnter(Collider other)
    {
        if (Trigger == null)
        {
            StartCoroutine(LightUp());
        }
    }



    public IEnumerator LightUp()
    {
        Light.enabled = true;
        fire.SetActive(true);
        Light.intensity = maxLight;
        yield return new WaitForSeconds(TimeToWait);
        Light.intensity = MidLight;
        yield return new WaitForSeconds(TimeToWait);
        Light.intensity = minLight;
        yield return new WaitForSeconds(TimeToWait);
    }
}
