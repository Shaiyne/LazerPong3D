using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreImageCreator : MonoBehaviour
{
    [SerializeField] GameObject scoreSprite;
    private void OnEnable()
    {
        PlayerSignals.Instance.onCreateScoreImage += OnPointInitialize;
    }
    private void OnDisable()
    {
        PlayerSignals.Instance.onCreateScoreImage -= OnPointInitialize;
    }
    private void OnPointInitialize(Transform _transform)
    {
        Instantiate(scoreSprite, _transform.position, Quaternion.Euler(30,0,0));
        ScoreManager.Instance.Score++;
    }
}
