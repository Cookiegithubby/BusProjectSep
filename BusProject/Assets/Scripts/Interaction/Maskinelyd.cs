using UnityEngine;

public class Checkind : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Controller" && audioSource != null)
        {
           if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
           audioSource.Play();
        }
        
    }
}
