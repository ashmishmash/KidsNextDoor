
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadSceneAsync(1);
    }
}
