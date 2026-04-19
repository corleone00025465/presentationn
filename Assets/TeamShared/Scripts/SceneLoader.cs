using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance; // 单例，全局可调用

    void Awake()
    {
        // 单例初始化，切换场景不销毁
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 加载指定名称的场景
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // 加载前恢复游戏时间，避免暂停状态残留
        SceneManager.LoadScene(sceneName);
    }

    // 退出游戏
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}