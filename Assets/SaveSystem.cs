using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
   public static void SavePlayer(PlayerMovement2 player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);



        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveShooting(Shooting shooter)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shooter.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData shootingdata = new PlayerData(shooter);
        formatter.Serialize(stream, shootingdata);
        stream.Close();
    }


    public static PlayerData LoadShooting()
    {
        string path = Application.persistentDataPath + "/shooter.txt";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);


            PlayerData shootingdata = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return shootingdata;
        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.txt";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

         PlayerData data =  formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("save file not found in " + path);
                return null;
        }
    }
}
