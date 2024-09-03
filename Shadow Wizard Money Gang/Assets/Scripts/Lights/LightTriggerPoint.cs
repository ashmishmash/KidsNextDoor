using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerPoint : MonoBehaviour
{
    public Light Light;
    public bool LightOn;
    public float maxLight;
    public float MidLight;
    public float minLight;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            //Debug.Log("light on");
            //Light.enabled = true;
            //Destroy(this.gameObject);
            LightOn = true;
        }
    }

    private void Update()
    {
        if (LightOn) 
        {
            StartCoroutine(FlameOn());
            //Debug.Log("light on");
        }
    }

    public IEnumerator FlameOn() 
    {
        Light.enabled = true;
        Light.intensity = maxLight;
        yield return new WaitForSeconds(5);
        Light.intensity = MidLight;
        yield return new WaitForSeconds(5);
        Light.intensity = minLight;
        yield return new WaitForSeconds(5);
        Light.enabled = false;
        LightOn = false;
    }
    
}
