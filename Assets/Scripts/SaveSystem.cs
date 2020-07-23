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

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;

            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("SaveData in " + path + " not found.");
            return null;
        }
    }
}
