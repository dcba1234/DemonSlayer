using Assets.Scripts.Player.Model;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

[System.Serializable]
public class PlayerEntity 
{
    public Level Level;
    public float MaxHeart;
    public float CurrentHeart;
    public int Armor;
    public float MaxMana;
    public float CurrentMana;
    public Position CurrentPosition;
    public int Coin;
    public int Diamond;
    public PlayerEntity(Transform transform)
    {
        CurrentPosition = new Position();
        CurrentPosition.x = transform.position.x;
        CurrentPosition.y = transform.position.y;
        Level = new Level();
        MaxHeart = 100;
        MaxMana = 100;
        Armor = 0;
        CurrentHeart = MaxHeart;
        CurrentMana = MaxMana;
        Coin = 0;
        Diamond = 0;
    }
    public void setPosition(Transform transform)
    {
        this.CurrentPosition.x = transform.position.x;
        this.CurrentPosition.y = transform.position.y;
    }
    public void gainCoin(int Coin)
    {
        this.Coin += Coin;
    }
    public void gainDiamon(int Diamon)
    {
        this.Diamond += Diamon;
    }
    public PlayerEntity()
    {
        Level = new Level();
    }
    /// <summary>
    /// Hàm tăng  level ,
    ///  max exp tăng 40% mỗi khi lên lv , 
    ///  trả về true nếu level up
    /// </summary>
    public bool gainExp(int exp)
    {
        return Level.gainExp(exp);
    }


    /// <summary>
    /// Lấy những gì đã lưu
    /// </summary>
    public PlayerEntity getState()
    {
        PlayerEntity player = new PlayerEntity();
        // do smt
        string path = Application.persistentDataPath + "/player.now";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            player = formatter.Deserialize(stream) as PlayerEntity;
            stream.Close();
        } else
        {
            throw new Exception("Không tìm thấy file save");
        }
        return player;
    }

    public bool checkSaveState()
    {
        string path = Application.persistentDataPath + "/player.now";
        return File.Exists(path);
    }

}
