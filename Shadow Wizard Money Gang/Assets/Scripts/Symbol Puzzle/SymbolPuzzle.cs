using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SymbolPuzzle : MonoBehaviour
{
    //public bool count1 = false;
    //public bool count2 = false;
    //public bool count3 = false;
    public FirstPersonControls firstPersonControls;
    public Material Red;
    public Material Green;
    public Material White;
    
    public Renderer Renderer;

    public GameObject keyDoor;
  

    private void OnTriggerEnter(Collider collider)
    {
       if (collider.CompareTag("Player"))
       {
            Debug.Log("player collided");
            
            if (gameObject.CompareTag("Symbol1") && firstPersonControls.count1 == false)
            {
                Debug.Log("Yay symbol 1");
                firstPersonControls.count1 = true;
                StartCoroutine(FlashGreen());
                Debug.Log("count1 is true");
            }
            else if (gameObject.CompareTag("Symbol2") && firstPersonControls.count1 == true && firstPersonControls.count2 == false)
            {
                Debug.Log("Yay symbol 2");
                firstPersonControls.count2 = true;
                Debug.Log("count2 is true");
                StartCoroutine(FlashGreen());
            }
            else if (gameObject.CompareTag("Symbol3") && firstPersonControls.count3 == false && firstPersonControls.count1 == true && firstPersonControls.count2 == true)
            {
                Debug.Log("Yay symbol 3");
                firstPersonControls.count3 = true;
                //Debug.Log(count);
                StartCoroutine(FlashGreen());
            }
            else 
            {
                Debug.Log("Boo wrong symbol");
                firstPersonControls.count1 = false;
                firstPersonControls.count2 = false;
                firstPersonControls.count3 = false;
                //Debug.Log(count);
                StartCoroutine(FlashRed());
            }

            if (firstPersonControls.count3 == true)
            {
                Debug.Log("UNLOCKED");
                //open the key box and float key toward player
                keyDoor.SetActive(false);
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
