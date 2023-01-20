using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController
{
    Animator animator;
    public PlayerAnimationController(PlayerManager playerManager)
    {
        animator = playerManager.transform.gameObject.GetComponent<Animator>();
    }
    public void ChangePlayerAnimation(PlayerAnimationStates animationStates)
    {
        switch (animationStates)
        {
            case PlayerAnimationStates.PlayerIdle:
                animator.Play(animationStates.ToString());
                break;
            case PlayerAnimationStates.PlayerRun:
                animator.Play(animationStates.ToString());
                break;
            case PlayerAnimationStates.PlayerJump:
                animator.Play(animationStates.ToString());
                break;
            case PlayerAnimationStates.PlayerDied:
                animator.Play(animationStates.ToString());
                break;
        }
    }
}
