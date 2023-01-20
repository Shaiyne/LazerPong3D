using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICountdown : MonoBehaviour
{
    TextMeshProUGUI text;
    float countdowner = 4;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        Countdown();
        if (countdowner == 0)
        {
            CoreSignals.Instance.onGameBegin?.Invoke();
            this.gameObject.SetActive(false);
        }
    }
    public void Countdown()
    {
        countdowner -= Time.deltaTime;
        if (countdowner <= 0) countdowner = 0;
        text.text = " " + (int)countdowner;
    }
}
