using UnityEngine;

public class Extinguishing : MonoBehaviour
{
    public float fireReduction = 0.1f;
    public float fireSizeThreshold = 0.1f;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Debug.Log("FIRE DEBUGGING - Collided with fire");

            Transform[] childs = other.GetComponentsInChildren<Transform>();

            foreach (Transform child in childs)
            {
                if (child.tag == "FireParticles")
                {
                    Debug.Log("FIRE DEBUGGING - Found FireParticle: " + child.name + " X scale = " + child.transform.localScale.x);

                    child.transform.localScale -= new Vector3(fireReduction, fireReduction, fireReduction) * Time.deltaTime;

                    Debug.Log("FIRE DEBUGGING - Child scale is now: " + child.transform.localScale.x);

                    if (child.transform.localScale.x <= fireSizeThreshold)
                    {
                        Debug.Log("FIRE DEBUGGING - Extinguished fire");
                        Destroy(other.gameObject);
                        //Add score to scoremanager
                    }
                }
            }
        }
    }
}
