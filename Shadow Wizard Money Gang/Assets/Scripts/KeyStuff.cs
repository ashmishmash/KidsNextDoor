using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStuff : MonoBehaviour
{
    public FirstPersonControls firstPersonControls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.CompareTag("Player") && (firstPersonControls.keyCounter > 0)) // is player near door with key
            {
                //unlock door
            }
        }
    }

}
