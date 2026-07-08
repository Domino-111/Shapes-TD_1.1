using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    public DataManager data;

    public TMP_Text scoreText, highScoreText;
    public int score = 0;
    public int highScore;

    // Keep track of canvases involved with the game
    public GameObject menuPage, scorePage, gameSettings, instructionsPage;

    public bool isPlaying = false, gameEnded = false, inMenu = true;

    void Awake()
    {
        game = this;
        isPlaying = false;
        gameEnded = false;
        inMenu = true;

        menuPage.SetActive(true);
        scorePage.SetActive(false);
        gameSettings.SetActive(false);
        instructionsPage.SetActive(false);
    }

    // Constantly update the score once an enemy is defeated
    void Update()
    {
        if (gameEnded == true)
        {
            UpdateScore();
        }
    }

    // Restarts the game
    public void Restart()
    {
        SceneManager.LoadScene("Final Game");
    }

    // Updates the score text
    public void UpdateScore()
    {
        scoreText.text = "Score:\n" + score.ToString();

        if (highScore < score)
        {
            highScore = score;
            data.SavedGame();
            highScoreText.text = "High-Score:\n" + highScore.ToString();
        }

        else
        {
            highScoreText.text = "High-Score:\n" + highScore.ToString();
        }
    }

    // Opens the settings in the menu
    public void OpenGameSettings()
    {
        if (inMenu == false)
        {
            isPlaying = false;
            Time.timeScale = 0f;
        }

        gameSettings.SetActive(true);
    }

    // Closes the settings in the menu
    public void CloseGameSettings()
    {
        if (inMenu == false)
        {
            isPlaying = true;
            Time.timeScale = 1f;
        }

        gameSettings.SetActive(false);
    }

    // Opens the instructions page
    public void OpenInstructions()
    {
        instructionsPage.SetActive(true);
    }

    // Closes the instructions page
    public void CloseInstructions()
    {
        instructionsPage.SetActive(false);
    }
}
