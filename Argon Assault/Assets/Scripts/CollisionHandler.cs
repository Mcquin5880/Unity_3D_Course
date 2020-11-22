using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.5f;
    [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") return;
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {       
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
