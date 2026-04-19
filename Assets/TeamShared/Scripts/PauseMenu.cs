using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject helpPanel; // 新增帮助面板字段

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        helpPanel.SetActive(false); // 关闭时同时隐藏帮助面板
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void OpenSettings()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneLoader.Instance.LoadScene("MainMenu");
    }

    // 新增帮助面板方法
    public void OpenHelp()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    public void CloseHelp()
    {
        helpPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}