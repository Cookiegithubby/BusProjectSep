using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Controller")) return;

        triggered = true;
        SceneManager.LoadScene("Patrick_TestScene_JL"); // skriv navnet på den rigtige scenenavn her
    }
}
