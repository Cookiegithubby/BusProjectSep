using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;   // til RestartScene

public class BusCountdownTimer : MonoBehaviour
{
    [Header("Timer indstillinger")]
    [SerializeField] private float startTimeSeconds = 300f;
    [SerializeField] private bool startOnAwake = true;

    [Header("UI reference")]
    [SerializeField] private TextMeshProUGUI timerText;    // Text (TMP) på bus-skærmen

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;    // Canvas med Game Over
    [SerializeField] private bool pauseGameOnEnd = true;   // skal Time.timeScale sættes til 0?

    private float currentTime;
    private bool isRunning = false;

    private void Awake()
    {
        if (timerText == null)
            timerText = GetComponentInChildren<TextMeshProUGUI>();

        // Sørg for at Game Over-skærmen er skjult i starten
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);

        SetTime(startTimeSeconds);

        if (startOnAwake)
            StartTimer();
        else
            UpdateText();
    }

    private void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;

            HandleGameOver();
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

    private void HandleGameOver()
    {
        // Pause hele spillet (valgfrit)
        if (pauseGameOnEnd)
            Time.timeScale = 0f;

        // Vis Game Over-skærmen
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);
    }

    // Offentlige metoder, hvis du vil styre timeren udefra -------------

    public void SetTime(float seconds)
    {
        currentTime = Mathf.Max(0f, seconds);
        UpdateText();
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        SetTime(startTimeSeconds);
    }

    public void StartNewTimer(float seconds)
    {
        Time.timeScale = 1f; // hvis du starter forfra efter Game Over
        SetTime(seconds);
        StartTimer();

        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
    }

    // Knaphandlinger til Game Over UI ---------------------------------

    public void RestartScene()
    {
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
