using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MaxScoreText;
    [SerializeField] GameObject GameEndedUI;
    [SerializeField] Image ScoreImage;
    [SerializeField] Button StartButton;
    [SerializeField] TextMeshProUGUI StartCountdown;
    //
    private void Awake()
    {
        SaveGameManager.LoadGame();
    }
    public void ScorePoint()
    {
        ScoreImage.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = " " + ScoreManager.Instance.Score ;
    }
    public void MaxScore() 
    {
        SaveGameManager.LoadGame();
        MaxScoreText.text = "Max Score :  " + ScoreManager.Instance.MaxScore + " Your Score : " + ScoreManager.Instance.Score;
    }

    public void GameEnded()
    {
        GameEndedUI.gameObject.SetActive(true);
        MaxScore();
    }
    public void GameStart()
    {
        StartButton.gameObject.SetActive(false);
        StartCountdown.gameObject.SetActive(true);
        ScoreImage.gameObject.SetActive(true);
    }
}
