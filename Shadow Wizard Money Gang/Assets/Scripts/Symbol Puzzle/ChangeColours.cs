using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColours : MonoBehaviour
{

    public FirstPersonControls controls;
    public GameObject[] blocks;
    public Material Green;


    // Update is called once per frame
    void Update()
    {
        if (controls.isSolved)
        {
            foreach (GameObject obj in blocks)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = Green; // Set the color to match the switch material color
                }
            }
        }
    }
}
