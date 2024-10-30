using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class FallingScript : MonoBehaviour
{
    [Header("screen shots")]
public GameObject StartRoom;
public GameObject SymbolPuzzle;
public GameObject DoorPuzzle;
public GameObject Skull;
public GameObject CatNip;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        //play falling animation
        StartCoroutine(WaitToChange());
    }

  public IEnumerator WaitToChange()
    {
        yield return new WaitForSeconds(0.5f);
        SymbolPuzzle.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SymbolPuzzle.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        DoorPuzzle.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DoorPuzzle.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Skull.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Skull.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        CatNip.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Debug.Log(Player.transform.position);
        SceneManager.LoadSceneAsync(3);
    }
}
