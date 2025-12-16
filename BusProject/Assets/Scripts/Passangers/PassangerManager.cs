using NUnit.Framework;
using UnityEngine;

public class PassangerManager : MonoBehaviour
{
    [SerializeField] private Passanger[] passangers = new Passanger[3];
    [SerializeField] private ScoreManager scoreManager;
    public bool glassBroken;
    private int evacuateCount;

    private void Start()
    {
        GameObject[] pass = GameObject.FindGameObjectsWithTag("Passenger");
        for (int i = 0; i < pass.Length; i++)
        {
            passangers[i] = pass[i].GetComponent<Passanger>();
        }
    }

    public void addScore(int value, bool evacuation)
    {
        scoreManager.addToScore(value);
        if (evacuation) evacuateCount++;
        if (evacuateCount > 2) { /*Change scene*/ }
    }

    public void GlassBreak()
    {
        glassBroken = true;
        for (int i = 0;i < passangers.Length; i++)
        {
            if (passangers[i].state == currentState.WaitingByWindow) passangers[i].state = currentState.Evacuate;
        }
    }
}
