using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject levelList, endlessLevel;

    public List<GameObject> levels;

    public GameManager gm;

    void Awake()
    {
        levelList.SetActive(false);
        endlessLevel.SetActive(false);

        // Ensures all the objects in the list aren't active before the game begins
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].SetActive(false);
        }
    }

    // Opens the list of the levels
    public void OpenLevelList()
    {
        levelList.SetActive(true);

        Invoke("CloseLevelList", 5);
    }

    // Closes the list of levels after a few seconds
    public void CloseLevelList()
    {
        levelList.SetActive(false);
    }

    // Plays the endless level
    public void EndlessMode()
    {
        endlessLevel.SetActive(true);
        gm.menuPage.SetActive(false);
    }

    // Play the first level
    public void PlayLevelOne()
    {
        levels[0].SetActive(true);
        gm.menuPage.SetActive(false);
    }
}
