using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public GameObject losePanel;

    [Header("Game")]
    public int startLives = 3;

    [Tooltip(">0 = skaita UZ LEJU, 0 = skaita UZ AUGŠU")]
    public float countdownSeconds = 0f;

    [Header("Audio")]
    public AudioSource sfxSource;

    public bool IsRunning { get; private set; }

    private int score;
    private int lives;
    private float time;

    private void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        // Ja kaut kur bija pauze
        Time.timeScale = 1f;

        score = 0;
        lives = startLives;

        if (countdownSeconds > 0f)
            time = countdownSeconds;
        else
            time = 0f;

        IsRunning = true;

        if (losePanel != null) losePanel.SetActive(false);

        UpdateScoreUI();
        UpdateTimerUI();

        Debug.Log("Game started. IsRunning=" + IsRunning + " time=" + time);
    }

    private void Update()
    {
        if (!IsRunning) return;

        // Skaita laiku
        if (countdownSeconds > 0f)
        {
            time -= Time.deltaTime;
            if (time <= 0f)
            {
                time = 0f;
                GameOver();
            }
        }
        else
        {
            time += Time.deltaTime;
        }

        UpdateTimerUI();
    }

    public void AddScore(int amount)
    {
        if (!IsRunning) return;
        score += amount;
        UpdateScoreUI();
    }

    public void LoseLife(int amount)
    {
        if (!IsRunning) return;

        lives -= amount;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
    }

    private void GameOver()
    {
        IsRunning = false;
        if (losePanel != null) losePanel.SetActive(true);

        Debug.Log("GAME OVER. time=" + time);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    private void UpdateTimerUI()
    {
        if (timerText == null) return;

        int totalSeconds = Mathf.CeilToInt(time);
        int min = totalSeconds / 60;
        int sec = totalSeconds % 60;

        timerText.text = $"Time: {min:00}:{sec:00}";
    }

    public void PlaySfx(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;
        sfxSource.PlayOneShot(clip);
    }
}
