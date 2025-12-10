using NUnit.Framework;
using UnityEngine;

public class PassangerManager : MonoBehaviour
{
    [SerializeField] private Passanger[] passangers = new Passanger[3];
    [SerializeField] private ScoreManager scoreManager;
    public bool glassBroken;

    private void Start()
    {
        GameObject[] pass = GameObject.FindGameObjectsWithTag("Passenger");
        for (int i = 0; i < pass.Length; i++)
        {
            passangers[i] = pass[i].GetComponent<Passanger>();
        }
    }

    public void addScore(int value)
    {
        scoreManager.addToScore(value);
    }
}
