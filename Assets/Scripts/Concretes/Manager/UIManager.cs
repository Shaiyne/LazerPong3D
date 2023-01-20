using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    UIController uIController;
    private void Awake()
    {
        uIController = GetComponent<UIController>();
    }

    private void OnEnable()
    {
        UISignals.Instance.onScorePoint += OnScorePoint;
        CoreSignals.Instance.onGameEnded += OnGameEnded;
    }
    private void OnDisable()
    {
        UISignals.Instance.onScorePoint -= OnScorePoint;
        CoreSignals.Instance.onGameEnded -= OnGameEnded;
    }

    public void GameStartButton()
    {
        uIController.GameStart();      
    }

    public void OnScorePoint()
    {
        uIController.ScorePoint();
    }

    private void OnGameEnded()
    {
        uIController.GameEnded();
    }
    public void TryAgainButton()
    {
        CoreSignals.Instance.onGameRestart?.Invoke();
    }

    public void TwoDGameButton()
    {
        CoreSignals.Instance.on2DGameOpen?.Invoke();
    }
    public void ThreeDGameButton()
    {
        CoreSignals.Instance.on3DGameOpen?.Invoke();
    }
}
