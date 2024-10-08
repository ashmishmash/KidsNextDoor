using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggers : MonoBehaviour
{
    public GameObject[] Triggers;

    public void OnTriggerEnter(Collider other)
    {
        if (CompareTag("MoveLook"))
        {
            MoveLook();
        }

        if (CompareTag("Sprint"))
        {
            Sprint();
        }

        if (CompareTag("Jump"))
        {
            Jump();
        }

        if (CompareTag("Crouch"))
        {
            Crouch();
        }

        if (CompareTag("LaserTut"))
        {
            Laser();
        }

        if (CompareTag("PauseTut"))
        {
            Pause();
        }
    }
    public void MoveLook()
    {
        Triggers[0].SetActive(false);
        Triggers[1].SetActive(false);
    }

    public void Sprint()
    {
        Triggers[2].SetActive(true);
        StartCoroutine(WaitToGo());
    }

    public void Jump()
    {
        Triggers[3].SetActive(true);
        StartCoroutine(WaitToGo());
    }

    public void Crouch()
    {
        Triggers[4].SetActive(true);
        StartCoroutine(WaitToGo());
    }

    public void Laser()
    {
        Triggers[0].SetActive(true);
        StartCoroutine(WaitToGo());
    }

    public void Pause()
    {
        Triggers[1].SetActive(true);
        StartCoroutine(WaitToGo());
    }
    public IEnumerator WaitToGo()
    {
        yield return new WaitForSeconds(3f);
        Triggers[0].SetActive(false);
        Triggers[1].SetActive(false);
        Triggers[2].SetActive(false);
        Triggers[3].SetActive(false);
        Triggers[4].SetActive(false);
    }
}
