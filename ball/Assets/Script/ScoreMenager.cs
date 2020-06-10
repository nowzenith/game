using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMenager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScore;
    static public int scoreValue = 0;

    private void Start()
    {
        scoreValue = 0;
    }
    void Update()
    {
        scoreText.text = "Score : " + scoreValue.ToString();
    }
}
