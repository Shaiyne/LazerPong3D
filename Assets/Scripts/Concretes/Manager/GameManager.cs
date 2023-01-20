using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    protected internal bool GameEndBool;
    private void OnEnable()
    {
        CoreSignals.Instance.onGameBegin += OnGameBegin;
        CoreSignals.Instance.onGameEnded += OnGameEnded;
        CoreSignals.Instance.onGameRestart += OnGameRestart;
        CoreSignals.Instance.on2DGameOpen += On2DGameOpen;
        CoreSignals.Instance.on3DGameOpen += On3dGameOpen;
    }

    private void OnDisable()
    {
        CoreSignals.Instance.onGameBegin -= OnGameBegin;
        CoreSignals.Instance.onGameEnded -= OnGameEnded;
        CoreSignals.Instance.onGameRestart -= OnGameRestart;
        CoreSignals.Instance.on2DGameOpen -= On2DGameOpen;
        CoreSignals.Instance.on3DGameOpen -= On3dGameOpen;
    }
    private void OnGameBegin()
    {
        FindObjectOfType<AudioManager>().Play("GameMusic");
    }

    private void OnGameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnGameEnded()
    {
        FindObjectOfType<AudioManager>().transform.GetComponent<AudioSource>().Stop(); //GameMusic i kapatmak için
    }

    private void On2DGameOpen()
    {
        SceneManager.LoadScene("2DLevel");
    }

    private void On3dGameOpen()
    {
        SceneManager.LoadScene("3DLevel");
    }



}
