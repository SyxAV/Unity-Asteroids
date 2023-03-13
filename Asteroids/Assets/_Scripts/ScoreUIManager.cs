using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;

    void OnEnable()
    {
        Asteroid.OnPointsGained += OnPointsGained;
    }

    void OnDisable()
    {
        Asteroid.OnPointsGained -= OnPointsGained;
    }

    void Start()
    {
        UpdateVisual();
    }

    private void OnPointsGained(int score)
    {
        _score += score;
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        _scoreText.text = $"Score = {_score}";
    }
}
