using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Extinguishing : MonoBehaviour
{
    public float fireReduction = 0.1f;
    public float fireSizeThreshold = 0.1f;
    [SerializeField] private float completionValue;
    public ScoreManager scoreManager;

    //private GameObject[] sprayedPassangers = new GameObject[3];

    [SerializeField] private List<GameObject> sprayedPassangers = new List<GameObject>();
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Transform[] childs = other.GetComponentsInChildren<Transform>();

            foreach (Transform child in childs)
            {
                if (child.tag == "FireParticles")
                {
                    child.transform.localScale -= new Vector3(fireReduction, fireReduction, fireReduction) * Time.deltaTime;

                    if (child.transform.localScale.x <= fireSizeThreshold)
                    {
                        Debug.Log("FIRE DEBUGGING - Extinguished fire");
                        Destroy(other.gameObject);
                        scoreManager.addToScore(completionValue);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Passenger")
        {
            other.gameObject.GetComponent<Animator>().SetBool("Spray", true);
            sprayedPassangers.Add(other.gameObject);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Passenger")
        {
            other.gameObject.GetComponent<Animator>().SetBool("Spray", false);
            sprayedPassangers.Remove(other.gameObject);
        }
            
    }

    public void resetPassanger()
    {
        foreach (GameObject passenger in sprayedPassangers)
            passenger.GetComponent<Animator>().SetBool("Spray", false);
    }
}
