using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Animator pauseAnimator;
 public void StartGame()
    {
        Debug.Log("start");
        //play door animation
        //wait a few seconds
        SceneManager.LoadSceneAsync(1);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        //open options panel
        pauseAnimator.enabled = true;
    }
}
