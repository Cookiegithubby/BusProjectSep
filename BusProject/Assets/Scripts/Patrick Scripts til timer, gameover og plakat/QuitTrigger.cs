using UnityEngine;

public class QuitTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Controller")) return;

        triggered = true;
        Application.Quit();
    }
}
