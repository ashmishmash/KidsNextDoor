using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Transform target;
    public GameObject Player;
    public GameObject lightning;
    public CharacterController characterController;
    public FirstPersonControls controls;

    public GameObject tobecontinued;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //characterController.enabled = false;
            //controls.lookSpeed = 1.5f;
            //controls.moveSpeed = 0;
            //lightning.SetActive(true);
            

            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        /*Player.transform.position = Vector3.MoveTowards(Player.transform.position,target.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target.position, 0.5f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target.position, 0.5f);
        //playerAnim.Play("float");
        StartCoroutine(Quit());*/

        yield return new WaitForSeconds(6f);
        SceneManager.LoadSceneAsync(4);

    }

    private IEnumerator Quit()
    {
        //tobecontinued.SetActive(true );
        yield return new WaitForSeconds(3f);
        tobecontinued.SetActive(false);
        Application.Quit();
    }

}
