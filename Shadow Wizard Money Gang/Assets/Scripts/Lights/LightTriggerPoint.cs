using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightTriggerPoint : MonoBehaviour
{
    public Light Light;
     public GameObject fire;
    public GameObject BurningSound;
      float TimeToWait = 5f;
      float maxLight = 40f;
      float MidLight = 30f;
      float minLight = 25f;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FlameOn());
            //Destroy(this.gameObject);
        }
    }


    public IEnumerator FlameOn() 
    {
        Light.enabled = true;
        fire.SetActive(true);
        BurningSound.SetActive(true);
        Light.intensity = maxLight;
        yield return new WaitForSeconds(TimeToWait);
        Light.intensity = MidLight;
        yield return new WaitForSeconds(TimeToWait);
        Light.intensity = minLight;
        yield return new WaitForSeconds(TimeToWait);
    }
    
}
