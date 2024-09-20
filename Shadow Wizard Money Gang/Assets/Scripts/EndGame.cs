using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Transform target;
    public GameObject Player;
    public GameObject lightning;
    public CharacterController characterController;
    public FirstPersonControls controls;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            characterController.enabled = false;
            controls.lookSpeed = 1.5f;
            controls.moveSpeed = 0;
            lightning.SetActive(true);

            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        Player.transform.position = Vector3.MoveTowards(Player.transform.position,target.position, 1f);
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target.position, 1f);
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target.position, 1f);
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, target.position, 1f);
        Application.Quit();
    }

}
