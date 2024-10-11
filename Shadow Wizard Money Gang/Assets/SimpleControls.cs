using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControls : MonoBehaviour
{
    [Header("Animators")]
    [Space(5)]
    public Animator bscrollAnim;
    public Animator pageAnim;
    public Animator pawsAnim;

    [Header("Controls menu stuff")]
    [Space(5)]
    public GameObject controlsCanvas;


    [Header("Pause Buttons")]
    [Space(5)]
    public GameObject closeButton;
    public void Controls()
    {
        controlsCanvas.SetActive(true);
        pageAnim.SetFloat("Speed", 1f);
        pageAnim.enabled = true;
       // pageAnim.Play("simple page open");

        bscrollAnim.SetFloat("Speed", 1f);
        bscrollAnim.enabled = true;
        //bscrollAnim.Play("bottom scroll open");

        pawsAnim.SetFloat("Speed", 1f);
        pawsAnim.enabled = true;


        StartCoroutine(WaitForAnim());
    }

    public IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(2f);
        closeButton.SetActive(true);

        pawsAnim.enabled = false;
        pageAnim.enabled = false;
        bscrollAnim.enabled = false;
    }

    public void CloseControls()
    {
        closeButton.SetActive(false);
        controlsCanvas.SetActive(false);
        bscrollAnim.enabled = false;
        pageAnim.enabled = false;
        pawsAnim.enabled = false;
    }


}
