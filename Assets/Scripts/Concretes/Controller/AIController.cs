using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    GameObject Ball;
    Vector3 firstPlacePosition;
    float speed = 15f;

    private void Awake()
    {
        firstPlacePosition = transform.position;
        Ball = GameObject.Find("Ball");
    }

    public void FollowBall()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y,Ball.transform.position.z), Time.deltaTime * speed);
    }
    public void BackToStartPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, firstPlacePosition, Time.deltaTime * speed / 6);
    }
}
