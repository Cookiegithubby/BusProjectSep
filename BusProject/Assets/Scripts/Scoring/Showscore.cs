using TMPro;
using UnityEngine;

public class Showscore : MonoBehaviour
{
    private ScoreManager scoreManager;
    private TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Scoremanager").GetComponent<ScoreManager>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();

        textMeshProUGUI.text = "Score: " + scoreManager.getScore();
    }

}
