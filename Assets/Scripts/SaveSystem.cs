using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    //static string path = Application.persistentDataPath + "/savedata.shesh";

    public static void Save()
    {
        string path = Application.persistentDataPath + "/savedata.shesh";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(GameObject.FindGameObjectWithTag("Player"));

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static SaveData Load()
    {
        string path = Application.persistentDataPath + "/savedata.shesh";
        FileStream stream = new FileStream(path, FileMode.Open);

        if (File.Exists(path) && stream.Length > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;

            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Exception caught in SaveSystem.Load(). Creating new SaveData...");

            BinaryFormatter formatter = new BinaryFormatter();
            SaveData data = new SaveData(GameObject.FindGameObjectWithTag("Player"));
            formatter.Serialize(stream, data);
            stream.Close();
            return data;
        }
    }
}
