﻿using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Image _healthBarFill = null;
    [SerializeField] private Image _specialStatus = null;
    private int _maxHealth = 3;

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateHealth(int health)
    {
        _healthBarFill.fillAmount = (float)health / _maxHealth;
    }

    public void UpdateSpecialStatus(bool hasSpecial)
    {
        _specialStatus.color = hasSpecial ? Color.green : Color.red;
    }
}
