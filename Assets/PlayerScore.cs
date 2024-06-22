using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    [SerializeField] private TMP_Text m_scoreText;
    [SerializeField] private float m_scoreIncreaseSpeed;
    private float m_score;

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        m_score += Time.deltaTime * m_scoreIncreaseSpeed;
        m_scoreText.text = m_score.ToString("F0");
    }

    public float GetScore()
    {
        return m_score;
    }
}
