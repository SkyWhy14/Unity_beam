using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public GameObject losePanel;

    [Header("Lives (Hearts)")]
    public Image[] hearts;      // iemet 3 Image te
    public int startLives = 3;  // jābūt = hearts.Length

    [Header("Timer")]
    public float countdownSeconds = 0f; // 0 = count up, >0 = count down

    [Header("Audio")]
    public AudioSource sfxSource;

    public bool IsRunning { get; private set; }

    int score;
    int lives;
    float time;

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
    }

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        score = 0;

        // Drošība: ja hearts ir ielikti, paņem lives pēc masīva garuma
        if (hearts != null && hearts.Length > 0)
            lives = hearts.Length;
        else
            lives = startLives;

        time = countdownSeconds > 0 ? countdownSeconds : 0f;
        IsRunning = true;

        if (losePanel != null) losePanel.SetActive(false);

        UpdateScoreUI();
        UpdateTimerUI();
        UpdateHeartsUI();
    }

    void Update()
    {
        if (!IsRunning) return;

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

    public void LoseLife(int amount = 1)
    {
        if (!IsRunning) return;

        lives -= amount;
        if (lives < 0) lives = 0;

        UpdateHeartsUI();

        if (lives == 0)
            GameOver();
    }

    void UpdateHeartsUI()
    {
        if (hearts == null) return;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
                hearts[i].enabled = (i < lives); // pazūd 1 bilde, kad lives krīt
        }
    }

    void GameOver()
    {
        IsRunning = false;
        if (losePanel != null) losePanel.SetActive(true);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    void UpdateTimerUI()
    {
        if (timerText == null) return;

        int t = Mathf.CeilToInt(time);
        int min = t / 60;
        int sec = t % 60;
        timerText.text = $"Time: {min:00}:{sec:00}";
    }

    public void PlaySfx(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;
        sfxSource.PlayOneShot(clip);
    }
}
