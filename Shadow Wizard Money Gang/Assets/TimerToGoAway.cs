using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerToGoAway : MonoBehaviour
{
    public float timer;
    public float MaxTime;
    public GameObject readMe;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > MaxTime )
        {
            readMe.SetActive(false);
            
        }
    }

   
}
