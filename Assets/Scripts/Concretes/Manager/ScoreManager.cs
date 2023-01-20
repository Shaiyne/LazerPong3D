using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    protected internal int Score;
    ScoreSaveData scoreSave = new ScoreSaveData();
    protected internal int MaxScore;


    private void OnEnable()
    {
        CoreSignals.Instance.onGameBegin += OnGameBegin;
        CoreSignals.Instance.onGameEnded += OnGameEnded;

    }

    private void OnDisable()
    {
        CoreSignals.Instance.onGameEnded -= OnGameEnded;
    }

    private void OnGameBegin()
    {
        MaxScore = SaveGameManager.CurrentSaveData.ScoreSaveData.ScoreDataInt;
    }

    private void OnGameEnded()
    {
        //Score Kayýt 
        if (SaveGameManager.CurrentSaveData.ScoreSaveData.ScoreDataInt < Score) // Son skor kayýtlý en büyük skordan büyükse son skor kayýt için
        {
            SaveGameManager.CurrentSaveData.ScoreSaveData.ScoreDataInt = Score;
            SaveGameManager.SaveGame();
        }
    }
}
