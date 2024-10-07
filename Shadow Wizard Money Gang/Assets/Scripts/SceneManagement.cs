using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Animator tscrollAnim;
    public Animator bscrollAnim;
    public Animator pageAnim;
    public Animator pawsAnim;

    public Animator doorAnimator;
    public Animator cameraAnimator;
    public GameObject OptionsMenu;

    public StartScreemAudio StartScreemAudio;
 public void StartGame()
    {
        Debug.Log("start");
        //play door animation
        doorAnimator.enabled = true;
        cameraAnimator.SetBool("isStart", true);
        //wait a few seconds
        StartCoroutine(WaitDoor());
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        //open options panel
        OptionsMenu.SetActive(true);
        tscrollAnim.enabled = true;
        bscrollAnim.enabled = true;
        pageAnim.enabled = true;
        pawsAnim.enabled = true;
        StartScreemAudio.StartScreenPlaying = false;

    }

    public IEnumerator WaitDoor()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(1);
    }
}
