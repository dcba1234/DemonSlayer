using System;

[Serializable]
public class GameSetting 
{
    public bool sound;
    public bool music;
    public bool vibration;

    public GameSetting(bool sound, bool music, bool vibration)
    {
        this.sound = sound;
        this.music = music;
        this.vibration = vibration;
    }
    
}
