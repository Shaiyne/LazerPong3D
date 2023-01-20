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
        //Score Kay�t 
        if (SaveGameManager.CurrentSaveData.ScoreSaveData.ScoreDataInt < Score) // Son skor kay�tl� en b�y�k skordan b�y�kse son skor kay�t i�in
        {
            SaveGameManager.CurrentSaveData.ScoreSaveData.ScoreDataInt = Score;
            SaveGameManager.SaveGame();
        }
    }
}
