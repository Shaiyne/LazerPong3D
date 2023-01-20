using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreImageMovement : MonoBehaviour
{
    GameObject finalDestination;
    float speed = 20;
    private void Awake()
    {
        finalDestination = GameObject.Find("ScoreDestination");
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, finalDestination.transform.position, Time.deltaTime * speed);
        if(transform.position == finalDestination.transform.position)
        {
            Destroy(this.gameObject);
        }
    }
}
