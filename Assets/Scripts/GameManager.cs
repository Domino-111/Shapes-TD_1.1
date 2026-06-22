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
    public GameObject menuPage, gamePage, scorePage, audioSettings, instructionsPage;

    public bool isPlaying = false, gameEnded = false, inMenu = true;

    void Awake()
    {
        game = this;
        isPlaying = false;
        gameEnded = false;
        inMenu = true;

        menuPage.SetActive(true);
        scorePage.SetActive(false);
        gamePage.SetActive(false);
        audioSettings.SetActive(false);
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

    // Begins the game
    public void StartGame()
    {
        menuPage.SetActive(false);
        gamePage.SetActive(true);

        isPlaying = true;
        inMenu = false;
    }

    // Opens the settings in the menu
    public void OpenAudioSettings()
    {
        if (inMenu == false)
        {
            isPlaying = false;
            Time.timeScale = 0f;
        }

        audioSettings.SetActive(true);
    }

    // Closes the settings in the menu
    public void CloseAudioSettings()
    {
        if (inMenu == false)
        {
            isPlaying = true;
            Time.timeScale = 1f;
        }

        audioSettings.SetActive(false);
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
