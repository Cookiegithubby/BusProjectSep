using UnityEngine;

public class Breakglass : MonoBehaviour
{
    public float forceNeeded;
    public GameObject brokenGlass;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter!");
        if (other.gameObject.tag == "Glassbreak")
        {
            brokenGlass.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
