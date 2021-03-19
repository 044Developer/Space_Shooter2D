using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;

public static class SaveDataManager 
{
    private const string PathSlash = "/";

    public static void Save<T>(T data, string directory, string fileName)
    {
        if (!DirectoryExists(directory))
        {
            Directory.CreateDirectory(Application.persistentDataPath + PathSlash + directory);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetFullPath(directory, fileName));
        bf.Serialize(file, data);
        file.Close();
    }

    public static T Load<T>(string directory, string fileName)
    {
        var data = default(T);

        if (SaveExists(directory, fileName))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(GetFullPath(directory, fileName), FileMode.Open);
                data = (T)bf.Deserialize(file);
                file.Close();

                return data;
            }
            catch (SerializationException)
            {
                Debug.Log("Failed to load file");
            }
        }

        return data;
    }

    private static bool SaveExists(string directory, string fileName)
    {
        return File.Exists(GetFullPath(directory, fileName));
    }

    private static bool DirectoryExists(string directory)
    {
        return Directory.Exists(Application.persistentDataPath + PathSlash + directory);
    }

    private static string GetFullPath(string directory, string fileName)
    {
        return Application.persistentDataPath + PathSlash + directory + PathSlash + fileName;
    }
}
