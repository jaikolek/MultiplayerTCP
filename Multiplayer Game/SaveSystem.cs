using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(Data data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Directory.GetCurrentDirectory() + "/roullete.rl";
        FileStream stream = new FileStream(path, FileMode.Create);

        Data saveData = new Data();
        saveData = data;

        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static Data LoadData()
    {
        string path = Directory.GetCurrentDirectory() + "/roullete.rl";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();

            return data;
        }
        else
        {
            Console.WriteLine("Save data not found in " + path);
            return null;
        }
    }
}
