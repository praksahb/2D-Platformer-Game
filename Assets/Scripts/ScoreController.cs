﻿using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }

    public void IncrementScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    public int GetScore()
    {
        return score;
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }
}
