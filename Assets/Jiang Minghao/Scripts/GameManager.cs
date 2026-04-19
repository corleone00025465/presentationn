using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int totalScore = 0;
    public int targetScore = 10; // 通关所需分数
    public TextMeshProUGUI scoreText;
    public GameObject winPanel;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        winPanel.SetActive(false);
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        totalScore += value;
        UpdateScoreUI();
        CheckWinCondition();
    }

    void UpdateScoreUI()
    {
        scoreText.text = $"分数: {totalScore}/{targetScore}";
    }

    void CheckWinCondition()
    {
        if (totalScore >= targetScore)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f; // 通关后暂停游戏
        }
    }
}