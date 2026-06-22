using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

public static class JSON_Manager
{
    public static void SaveToJSON(SavedData data)
    {
        string directory = Application.persistentDataPath + "/SavedData/";

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string json = JsonUtility.ToJson(data, true); // This is the JSON encryption!

        File.WriteAllText(directory + "highScoreDatabase.json", json);

        GUIUtility.systemCopyBuffer = directory; // This is the CTRL + C
    }

    public static SavedData LoadFromJSON()
    {
        string directory = Application.persistentDataPath + "/SavedData/" + "highScoreDatabase.json";

        if (File.Exists(directory))
        {
            // This is the "fun" stuff
            string json = File.ReadAllText(directory);

            return JsonUtility.FromJson<SavedData>(json); // This is the JSON decryption
        }

        else
        {
            Debug.Log("Load failed. No file found.");
            return null;
        }
    }
}

[Serializable]
public class SavedData
{
    public int highScore;
}
