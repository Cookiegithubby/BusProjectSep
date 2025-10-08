using UnityEngine;

public class Addrandomforce : MonoBehaviour
{
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            Vector3 randomForce = new Vector3(Random.Range(-2f, 3f), Random.Range(-2f, 4f), Random.Range(-2f, 1f));
            rb.AddForce(randomForce, ForceMode.Impulse);
        }
    }
}
