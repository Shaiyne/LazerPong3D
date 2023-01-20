using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPhysics : MonoBehaviour
{
    AIManager manager;
    private void Awake()
    {
        manager = GetComponent<AIManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LazerTag"))
        {
            AISignals.Instance.onStopAndOtherAICanMove.Invoke();
            manager.followLazerBall = false;
        }
    }
}
