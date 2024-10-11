
using System.Collections;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrap : MonoBehaviour
{
    public CharacterController characterController;
    public FirstPersonControls controls;

    public Animator camAnim;
    public ParticleSystem dust;
    public ParticleSystem rocks;

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
