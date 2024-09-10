using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SymbolPuzzle : MonoBehaviour
{
    public int count  = 0;
    public Material Red;
    public Material Green;
    public Material White;
    
    public MeshRenderer meshRenderer;

    public GameObject keyDoor;
  

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision detected");
       switch (count)
        {
            case 0:
                if (this.gameObject.tag == ("Symbol 1"))
                {
                    Debug.Log("Yay symbol 1");
                    count += 1;
                    FlashGreen();
                }
                else if (this.gameObject.tag == ("Wrong Symbol"))
                {
                    count = 0;
                    FlashRed();
                }
                break;
            case 1:
                if (this.gameObject.tag == ("Symbol 2"))
                {
                    count += 1;
                    FlashGreen();
                }
                else if (this.gameObject.tag == ("Wrong Symbol"))
                {
                    count = 0;
                    FlashRed();
                }
                break;
            case 2:
                if (this.gameObject.tag == ("Symbol 3"))
                {
                    count += 1;
                    FlashGreen();
                }
                else if (this.gameObject.tag == ("Wrong Symbol"))
                {
                    count = 0;
                    FlashRed();
                }
                break;
            case 3:
                //open the key box and float key toward player
                keyDoor.SetActive(false);
                break;
        }
    }

    public IEnumerator FlashGreen()
    {
        meshRenderer.material.color = Green.color;
        yield return new WaitForSeconds(2);
        meshRenderer.material.color = White.color;

    }

    public IEnumerator FlashRed()
    {
        meshRenderer.material.color = Red.color;
        yield return new WaitForSeconds(2);
        meshRenderer.material.color = White.color;

    }
}
