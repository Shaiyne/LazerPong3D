using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    AIController controller;
    bool canMove;
    protected internal bool followLazerBall=true;
    private void Awake()
    {
        controller = GetComponent<AIController>();
    }
    private void OnEnable()
    {
        AISignals.Instance.onStopAndOtherAICanMove += OnWakeUp;
        CoreSignals.Instance.onGameBegin += OnGameBegin;
        CoreSignals.Instance.onGameEnded += OnGameEnded;
    }

    private void OnWakeUp()
    {
        if (followLazerBall == false)
        {
            followLazerBall = true;
        }
    }

    private void OnDisable()
    {
        CoreSignals.Instance.onGameBegin -= OnGameBegin;
        CoreSignals.Instance.onGameEnded -= OnGameEnded;
        AISignals.Instance.onStopAndOtherAICanMove -= OnWakeUp;
    }
    private void Update()
    {
        if (canMove)
        {
            if (followLazerBall)
            {
                controller.FollowBall();
            }
            else
            {
                controller.BackToStartPosition();
            }
        }
    }
    private void OnGameBegin()
    {
        canMove = true;
    }
    private void OnGameEnded()
    {
        canMove = false;
    }
}
