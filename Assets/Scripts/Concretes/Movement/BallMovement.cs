using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 LastVelocity;
    float _speed=500;
    int ballDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ballDirection = Random.Range(0, 2);
        if(ballDirection == 0)
        {
            ballDirection = -1;
        }
        else
        {
            ballDirection = 1;
        }
    }

    private void OnEnable()
    {
        CoreSignals.Instance.onGameBegin += OnGameBegin;
        CoreSignals.Instance.onGameEnded += OnGameEnded;
    }
    private void OnDisable()
    {
        CoreSignals.Instance.onGameBegin -= OnGameBegin;
        CoreSignals.Instance.onGameEnded -= OnGameEnded;
    }
    private void OnGameBegin()
    {
        rb.AddForce(new Vector3(ballDirection * _speed, 0, ballDirection * _speed));
    }

    void Update()
    {
        LastVelocity = rb.velocity;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        var speed = LastVelocity.magnitude;
        var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    private void OnGameEnded()
    {
        rb.velocity = Vector3.zero;
        Destroy(this.gameObject);
    }


}
