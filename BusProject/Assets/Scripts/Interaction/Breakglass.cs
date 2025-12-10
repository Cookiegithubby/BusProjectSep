using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class Breakglass : MonoBehaviour
{
    public XRInputValueReader<Vector3> rightHandVelocity;
    public XRInputValueReader<Vector3> leftHandVelocity;
    public float forceNeeded;
    public GameObject brokenGlass;
    public AudioClip lightTap;
    public AudioClip glassBreak;
    public AudioSource audioSource;
    [SerializeField] private PassangerManager passangerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Glassbreak")
        {
            Vector3 rightVelo = rightHandVelocity.ReadValue();
            Vector3 leftVelo = leftHandVelocity.ReadValue();
            float maxVelo = Mathf.Max(rightVelo.magnitude, leftVelo.magnitude);
            if (maxVelo >= forceNeeded)
            {
                audioSource.clip = glassBreak;
                audioSource.Play();
                brokenGlass.SetActive(true);

                foreach (Transform child in brokenGlass.transform)
                {
                    Rigidbody rb = child.GetComponent<Rigidbody>();
                    Vector3 randomForce = new Vector3(Random.Range(-maxVelo, maxVelo*3), Random.Range(-maxVelo * 0.5f, maxVelo * 0.5f), Random.Range(-maxVelo, maxVelo));
                    rb.AddForce(randomForce, ForceMode.Impulse);
                }

                passangerManager.glassBroken = true;

                this.gameObject.SetActive(false);
            }
            else
            {
                audioSource.clip = lightTap;
                audioSource.Play();
            }
            
        }
    }
}
