using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float totalScore;
    
    public float getScore() { return  totalScore; }

    public void addToScore(float value) {  totalScore += value; }

}
