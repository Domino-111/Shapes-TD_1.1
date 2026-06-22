using UnityEngine;

public class DataManager : MonoBehaviour
{
    public GameManager gm;

    void Start()
    {
        LoadGame();
    }

    [ContextMenu("Save Game")]
    public void SavedGame()
    {
        print("Attempting to save game");

        SavedData savedData = new SavedData();
        savedData.highScore = gm.highScore;
        JSON_Manager.SaveToJSON(savedData);
    }

    [ContextMenu("Load Game")]
    public void LoadGame()
    {
        print("Attempting to load game");

        SavedData loadedData = JSON_Manager.LoadFromJSON();
        if (loadedData != null)
        {
            gm.highScore = loadedData.highScore;
        }

        else
        {
            SavedGame();
        }
    }
}
