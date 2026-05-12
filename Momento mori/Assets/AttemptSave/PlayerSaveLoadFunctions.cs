using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class PlayerSaveLoadFunctions
{
    public static void SavePlayer(PlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        SAvingSataTest data = new SAvingSataTest(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SAvingSataTest LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SAvingSataTest data = formatter.Deserialize(stream) as SAvingSataTest;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("save file not found" + path);
            return null;
        }

    }
}