﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSystem
{
    public static int soundVolume = 100;
    public static int musicVolume = 100;
    public static SystemLanguage gameLanguage = Application.systemLanguage;
    public const string playerSaveFileName = "/player.now";
    public const string settingSaveFileName = "/setting.now";
    public const string isFisrtTimeSaveFileName = "/isFirstTime.now";
    public const string coinFileName = "/coin.now";
    public static void test()
    {
        Debug.Log(soundVolume);
        changeLanguage(SystemLanguage.Vietnamese);
    }


    /// <summary>
    /// truyền vào 1 PlayerEntity
    /// </summary>
    public static void saveGame(PlayerEntity info)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + playerSaveFileName;
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, info);
        stream.Close();
    }


    /// <summary>
    /// Lấy những gì đã lưu và trả về 1 object
    /// </summary>
    public static PlayerEntity loadGame()
    {
        PlayerEntity player = new PlayerEntity();
        // do smt
        string path = Application.persistentDataPath + playerSaveFileName;
        Debug.Log(path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            player = formatter.Deserialize(stream) as PlayerEntity;
            stream.Close();
        }
        else
        {
            throw new Exception("Không tìm thấy file save");
        }
        return player;
    }

    public static void pauseGame()
    {
        Time.timeScale = 0;
    }
    public static void resumeGame()
    {
        Time.timeScale = 1;
    }
    public static void setMusicVolume(int value)
    {
        musicVolume = value % 100;
    }
    public static void setSoundVolume(int value)
    {
        soundVolume = value % 100;
    }
    public static void exitGame()
    {
        Application.Quit();
    }
    
    public static void changeLanguage(SystemLanguage language)
    {
        gameLanguage = language;
    }

    public static void saveGameSettings(GameSetting gameSetting)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + settingSaveFileName;
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, gameSetting);
        stream.Close();
    }

    public static bool isfistTime()
    {
        bool result = true;
        string path = Application.persistentDataPath + isFisrtTimeSaveFileName;
        if (File.Exists(path))
        {

            return false;
        }
        return true;
    }

    public static GameSetting loadGameSettings()
    {
        GameSetting setting = new GameSetting(true,true,true);
        // do smt
        string path = Application.persistentDataPath + settingSaveFileName;
        if (File.Exists(path))
        {
            
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            setting = formatter.Deserialize(stream) as GameSetting;
            stream.Close();
        }
        return setting;
    }


}
