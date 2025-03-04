using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject titleScreen; // Reference to the Title Screen UI

    private int highScore;
    private bool gameActive = false; // Track if the game is active

    void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();

        // Show the Title Screen and hide the game UI
        titleScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        scoreText.gameObject.SetActive(false);

        // Pause the game logic
        gameActive = false;
        Time.timeScale = 0; // Pause the game
    }

    public void StartGame()
    {
        // Hide the Title Screen and show the game UI
        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);

        // Reset the game state
        playerScore = 0;
        scoreText.text = playerScore.ToString();

        // Start the game logic
        gameActive = true;
        Time.timeScale = 1; // Unpause the game
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!gameActive) return; // Don't add score if the game isn't active

        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        // Check if the current score is higher than the high score
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateHighScoreText();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameActive = false; // Stop the game logic
    }

    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    public bool IsGameActive()
    {
        return gameActive;
    }
}