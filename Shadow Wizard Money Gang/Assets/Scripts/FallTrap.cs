
using System.Collections;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrap : MonoBehaviour
{
    [Header("controllers")]
    public CharacterController characterController;
    public FirstPersonControls controls;

    [Header("cut scene animations")]
    public Animator camAnim;
    public ParticleSystem dust;
    public ParticleSystem rocks;

    [Header("player objects")]
    public GameObject laser;
    public GameObject FallingObject;
    public GameObject Player;

    [Header("screen shots")]
    public GameObject StartRoom;
    public GameObject SymbolPuzzle;
    public GameObject DoorPuzzle;
    public GameObject Skull;
    public GameObject CatNip;



    private void OnTriggerEnter(Collider other)
    {
        DisableController();
        dust.enableEmission = true;
        rocks.enableEmission = true;
        camAnim.enabled = true;
        camAnim.Play("dungeon trigger");
        //start particle effects
        
        StartCoroutine(WaitToFall());
    }

    public IEnumerator WaitToFall()
    {
        yield return new WaitForSeconds(2f);
        //SceneManager.LoadSceneAsync(2);
        camAnim.StopPlayback();
        laser.SetActive(false);
        Player.transform.position = FallingObject.transform.position;
        //characterController.enabled = true;
        // yield return new WaitForSeconds(1f);
        characterController.enabled = false; /*
        StartRoom.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartRoom.SetActive(false);
        SymbolPuzzle.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SymbolPuzzle.SetActive(false);
        DoorPuzzle.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DoorPuzzle .SetActive(false);
        Skull.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Skull.SetActive(false);
        CatNip.SetActive(true);
        yield return new WaitForSeconds(1f);
        //CatNip .SetActive(false);
        */
        SceneManager.LoadSceneAsync(2);
    }

    public void DisableController()
    {
        characterController.enabled = false;
        controls.lookSpeed = 0;
        controls.canShoot = false;
        controls.crouchSpeed = 0;
        controls.jumpHeight = 0;
        controls.canCrouch = false;
    }
}
