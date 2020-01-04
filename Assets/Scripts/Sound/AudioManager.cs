using Assets.Scripts.Sound;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWithName(string name)
    {
        if (SettingUI.drafSetting.sound)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
    }
}
