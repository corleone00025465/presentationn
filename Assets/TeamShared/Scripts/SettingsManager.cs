using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // 加载上次保存的音量，默认0.7
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.7f);
        AudioListener.volume = volumeSlider.value;

        // 绑定滑块值变化事件
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // 实时调节音量并保存
    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
    }
}