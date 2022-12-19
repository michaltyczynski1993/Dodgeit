using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // variables
    public static GameManager instance;
    public Text scoreText;
    public Text gameOverText;
    public Text highScoreText;
    private int highScore;

    public bool isGameOver = false;

    // enemy speed and spawn time
    public float enemySpeed = 2f;
    public int score;

    private void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score " + score;
        if (score >= 30 && score % 5 == 0)
        {
            enemySpeed++;
            Debug.Log(enemySpeed);
        }
    }

    public void GameOver()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] moons = GameObject.FindGameObjectsWithTag("Moon");

        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
        for (int i = 0; i < moons.Length; i++)
        {
            Destroy(moons[i]);
        }
        Destroy(player);
        gameOverText.gameObject.SetActive(true);
        setHightScore();
    }

    private void setHightScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score: " + score.ToString();
        }
        else
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    // UI CONTROLLS
    public void ResetGame()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
