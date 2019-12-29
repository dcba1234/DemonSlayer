using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Image image;
    public Sprite onImage;
    public Sprite offImage;
    private GameSetting setting;
    public string Name;
    void Awake()
    {
        image = GetComponent<Image>();
        setting = GameSystem.loadGameSettings();

    }

    public void reLoad(GameSetting setting)
    {
        if (Name == Contanst.btnMusicToggleName)
        {
            if (setting.music == true) image.sprite = onImage;
            else image.sprite = offImage;
        }
        else if (Name == Contanst.btnSoundToggleName)
        {

            if (setting.sound == true) image.sprite = onImage;
            else image.sprite = offImage;
        }
        else if (Name == Contanst.btnVibrationToggleName)
        {

            if (setting.vibration == true) image.sprite = onImage;
            else image.sprite = offImage;
        }
    }
    
    public void onChange()
    {
        if (Name == Contanst.btnMusicToggleName)
        {
            if (setting.music == true)
            {
                image.sprite = offImage;
                setting.music = false;
                SettingUI.drafSetting.music = false;
            }
            else
            {
                setting.music = true;
                SettingUI.drafSetting.music = true;
                image.sprite = onImage;
            }
        }
        else if (Name == Contanst.btnSoundToggleName)
        {

            if (setting.sound == true)
            {
                image.sprite = offImage;
                setting.sound = false;
                SettingUI.drafSetting.sound = false;
            }
            else
            {
                SettingUI.drafSetting.sound = true;
                setting.sound = true;
                image.sprite = onImage;
            }
        }
        else if (Name == Contanst.btnVibrationToggleName)
        {

            if (setting.vibration == true)
            {
                image.sprite = offImage;
                setting.vibration = false;
                SettingUI.drafSetting.vibration = false;
            }
            else
            {
                SettingUI.drafSetting.vibration = true;
                setting.vibration = true;
                image.sprite = onImage;
            }
        }
        GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<BackgroundMusicHandle>().onSettingChange();

    }

}
