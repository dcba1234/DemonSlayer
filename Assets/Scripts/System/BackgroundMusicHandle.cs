using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicHandle : MonoBehaviour
{
    private AudioSource bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        bgMusic = GetComponent<AudioSource>();
        GameSetting setting = GameSystem.loadGameSettings();
        if (setting.music)
        {
            bgMusic.enabled = true;
        }
        else bgMusic.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onSettingChange()
    {
        GameSetting setting = SettingUI.drafSetting;
        if (setting.music)
        {
            bgMusic.enabled = true;
        }
        else bgMusic.enabled = false;
    }
}
