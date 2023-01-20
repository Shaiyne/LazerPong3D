using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    PlayerManager player;
    float currentTime;
    float lastTimeClick;
    float jumpSpeed = 6;
    Rigidbody rb;
    private void Awake()
    {
        player = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer ==LayerMask.NameToLayer("GroundLayer"))
        {
            player.isGround = true; // karakter zemindeyse atlayabilir
        }
    }

    public void OnJumping(Touch t)
    {
        if (t.phase == TouchPhase.Began && player.isGround)
        {
            if (currentTime - lastTimeClick < 0.6f) // for double touch control
            {
                FindObjectOfType<AudioManager>().Play("JumpSound");
                player.SetAnimatonStates(PlayerAnimationStates.PlayerJump);
                rb.velocity = Vector3.up * jumpSpeed;
                player.isGround = false;
            }
            lastTimeClick = currentTime;
        }
    }

    public void SetRBFreeze()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll; //Oyun bittiðinde topa çarptýðýnda aldýðý darbeyle uçmamasý ve buga girmemesi için
    }
}
