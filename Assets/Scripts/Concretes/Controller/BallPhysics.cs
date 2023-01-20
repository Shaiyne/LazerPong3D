using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreColliderTag"))
        {
            PlayerSignals.Instance.onCreateScoreImage?.Invoke(other.transform); //Playerýn konumunda Score resmi oluþturuyor
            UISignals.Instance.onScorePoint?.Invoke(); // UI'ýn score kýsmýndaki puaný arttýrýyor
            FindObjectOfType<AudioManager>().Play("ScoreSound");
        }
        if (other.gameObject.CompareTag("Player")) // For Lazer
        {
            HittingPlayer();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // For Ball
        {
           HittingPlayer();
        }
    }

    private void HittingPlayer()
    {
        CoreSignals.Instance.onGameEnded?.Invoke();
        FindObjectOfType<AudioManager>().Play("DieSound");
    }
}
