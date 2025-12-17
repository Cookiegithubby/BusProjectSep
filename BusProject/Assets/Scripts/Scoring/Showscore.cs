using TMPro;
using UnityEngine;

public class Showscore : MonoBehaviour
{
    private ScoreManager scoreManager;
    private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private bool updateOnFrame;
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Scoremanager").GetComponent<ScoreManager>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();

        textMeshProUGUI.text = "Score: " + scoreManager.getScore();
    }

    private void Update()
    {
        if (!updateOnFrame) return;

        textMeshProUGUI.text = "Score: " + scoreManager.getScore();
    }

}
