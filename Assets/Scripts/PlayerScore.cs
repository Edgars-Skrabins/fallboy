using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    const string m_HIGHSCORE_PREF = "Highscore";

    [SerializeField] private TMP_Text m_scoreText;
    [SerializeField] private TMP_Text m_highscoreText;
    [SerializeField] private float m_scoreIncreaseSpeed;

    private float m_score;

    private void Update()
    {
        UpdateScore();
        IsHighScore();
    }

    private void UpdateScore()
    {
        m_score += Time.deltaTime * m_scoreIncreaseSpeed;
        m_scoreText.text = m_score.ToString("F0");
    }

    private void UpdateHighscore()
    {
        int highscore = ((int)m_score);
        m_highscoreText.text = highscore.ToString();
        PlayerPrefs.SetInt(m_HIGHSCORE_PREF,highscore);
    }

    public float GetScore()
    {
        return m_score;
    }

    public bool IsHighScore()
    {
        int score = (int)m_score;
        int highscore = PlayerPrefs.GetInt(m_HIGHSCORE_PREF,0);

        if(score > highscore)
        {
            UpdateHighscore();
            return true;
        }

        return false;
    }

    public void ResetScores()
    {
        m_score = 0f;
    }
}
