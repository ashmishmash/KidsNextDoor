using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SymbolPuzzle : MonoBehaviour
{
    public FirstPersonControls firstPersonControls;
    public Material Red;
    public Material Green;
    public Material White;

    public Renderer Renderer;

    public GameObject keyDoor;

    public GameObject[] Blocks;

    private bool isSolved = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (isSolved == false)
        {
            if (collider.CompareTag("Player"))
            {
                if (gameObject.CompareTag("Symbol1") && firstPersonControls.count == 0)
                {
                    firstPersonControls.count += 1;
                    StartCoroutine(FlashGreen());
                }
                else if (gameObject.CompareTag("Symbol2") && firstPersonControls.count == 1)
                {
                    firstPersonControls.count += 1;
                    StartCoroutine(FlashGreen());
                }
                else if (gameObject.CompareTag("Symbol3") && firstPersonControls.count == 2)
                {
                    firstPersonControls.count += 1;
                    StartCoroutine(FlashGreen());
                }
                else
                {
                    Debug.Log("Boo wrong symbol");
                    firstPersonControls.count = 0;
                    StartCoroutine(FlashRed());
                }

                if (firstPersonControls.count == 3)
                {
                    Debug.Log("UNLOCKED");
                    //open the key box and float key toward player
                    keyDoor.SetActive(false);
                    isSolved = true;
                    foreach (GameObject obj in Blocks)
                    {
                        Renderer renderer = obj.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.material.color = Green.color; // Set the color to match the switch material color

                        }
                    }
                }

            }
        }
    }


        public IEnumerator FlashGreen()
        {
            Renderer.material = Green;
            yield return new WaitForSeconds(2);
            Renderer.material = White;

        }

        public IEnumerator FlashRed()
        {
            Renderer.material = Red;
            yield return new WaitForSeconds(2);
            Renderer.material = White;

        }

    
}

