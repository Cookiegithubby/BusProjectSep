using UnityEngine;
using UnityEngine.Audio;

public class Busstop : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject stopLight;
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag == "Controller" && audioSource != null && !stopLight.activeSelf)
        {
            audioSource.Play();
            stopLight.SetActive(true);
        }

    }
}
