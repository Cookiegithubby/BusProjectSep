using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BusCountdownTimer : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private float startTimeSeconds = 300f;
    [SerializeField] private bool startOnAwake = true;

    [Header("Bus display (TMP)")]
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("Game Over")]
    [SerializeField] private GameOverController gameOver;

    private float currentTime;
    private bool isRunning = false;

    private void Awake()
    {
        if (timerText == null)
            timerText = GetComponentInChildren<TextMeshProUGUI>();

        currentTime = Mathf.Max(0f, startTimeSeconds);
        UpdateText();

        if (startOnAwake)
            isRunning = true;
    }

    private void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;
            UpdateText();

            SceneManager.LoadScene("GameOverScene");

            return;
        }

        UpdateText();
    }

    private void UpdateText()
    {
        if (timerText == null) return;

        int totalSeconds = Mathf.CeilToInt(currentTime);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void StartNewTimer(float seconds)
    {
        Time.timeScale = 1f;
        currentTime = Mathf.Max(0f, seconds);
        isRunning = true;
        UpdateText();
    }
}
