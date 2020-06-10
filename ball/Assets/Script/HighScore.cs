using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    static public int scoreValue = 0;

    private void Start()
    {
        scoreValue = 0;
        highScore.text = "Highscore : " + PlayerPrefs.GetInt("highScore", 0).ToString();
    }
    void Update()
    {
        scoreValue = ScoreMenager.scoreValue;
        if (scoreValue > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", scoreValue);
        }
    }
}
