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

    public Audio Audio;


    private void OnTriggerEnter(Collider collider)
    {
        if (firstPersonControls.isSolved == false)
        {
            if (collider.CompareTag("Player"))
            {
                if (gameObject.CompareTag("Symbol1") && firstPersonControls.count == 0)
                {
                    firstPersonControls.count += 1;
                    Audio.SoundEffects.PlayOneShot(Audio.Correct);
                    StartCoroutine(FlashGreen());
                }
                else if (gameObject.CompareTag("Symbol2") && firstPersonControls.count == 1)
                {
                    firstPersonControls.count += 1;
                    Audio.SoundEffects.PlayOneShot(Audio.Correct);
                    StartCoroutine(FlashGreen());
                }
                else if (gameObject.CompareTag("Symbol3") && firstPersonControls.count == 2)
                {
                    firstPersonControls.count += 1;
                    Audio.SoundEffects.PlayOneShot(Audio.Correct);
                    StartCoroutine(FlashGreen());
                }
                else
                {
                    Debug.Log("Boo wrong symbol");
                    Audio.SoundEffects.PlayOneShot(Audio.Incorrect);
                    firstPersonControls.count = 0;
                    StartCoroutine(FlashRed());
                }

                if (firstPersonControls.count == 3)
                {
                    //Debug.Log("UNLOCKED");
                    //open the key box and float key toward player
                    keyDoor.SetActive(false);
                    firstPersonControls.isSolved = true;
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

