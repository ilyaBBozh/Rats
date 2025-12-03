using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;

    private void Start()
    {
        if(PlayerPrefs.GetInt("highscore") > highScore)
        {
            highScore = PlayerPrefs.GetInt("highscore");
        }
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;

        if (highScore < score)
        {
            highScore = score;
            SaveHighScore();
        }
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("highscore", highScore);
    }
}