using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    void Update()
    {
        scoreText.text = String.Format($"SCORE: {Player.Score}");
        highScoreText.text = String.Format($"HI-SCORE: {Player.HighestScore}");
    }
}
