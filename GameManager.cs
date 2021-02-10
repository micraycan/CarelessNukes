using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    public GameObject gameOverUI;
    public Text scoreText;
    public Text highScoreText;

    public int health;
    public int score;
    public int highScore;

    private void Awake()
    {
        health = 5;
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");

        Time.timeScale = 1;
        gameOverUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.DisplayHearts(health);

        if (health <= 0)
        {
            // gameover
            Time.timeScale = 0;
            gameOverUI.SetActive(true);

            if (score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }

        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score " + highScore;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ViewCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
