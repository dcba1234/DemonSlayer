using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;
    public GameSetting setting;
    public GameObject SoundBtn;
    public GameObject MusicBtn;
    public GameObject VibrationBtn;
    public static GameSetting drafSetting;
    private void Awake()
    {
        setting = GameSystem.loadGameSettings();
        drafSetting = setting;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openSetting()
    {
        menu.SetActive(true);
        setting = GameSystem.loadGameSettings();
        SoundBtn.GetComponent<ToggleButton>().reLoad(setting);
        MusicBtn.GetComponent<ToggleButton>().reLoad(setting);
        VibrationBtn.GetComponent<ToggleButton>().reLoad(setting);
    }

    public void saveSetting()
    {
        GameSystem.saveGameSettings(drafSetting);
        closeSetting();
    }
    public void closeSetting()
    {
        menu.SetActive(false);
        drafSetting = GameSystem.loadGameSettings();
        GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<BackgroundMusicHandle>().onSettingChange();
    }
}
