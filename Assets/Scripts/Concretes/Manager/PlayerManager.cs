using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    #region Movement
    PlayerMovement playerMovement;
    [SerializeField] bool canMove;
    [SerializeField] float moveSpeed;
    #endregion
    #region Physics
    PlayerPhysicsController playerPhysics;
    protected internal bool isGround;
    #endregion
    #region Animation
    protected internal Animator animator;
    PlayerAnimationController animationController;
    #endregion
    private void Awake()
    {
        playerMovement = new PlayerMovement(this);
        playerPhysics = GetComponent<PlayerPhysicsController>();
        animator = GetComponent<Animator>();
        animationController = new PlayerAnimationController(this);
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


    private void Update()
    {
        if (canMove)
        {
            int i = 0;
            while (i < Input.touchCount) //phaselerin(began,ended,moved) if koþulu içine koþul olarak yazýldýðýnda index hatasý verdiði için böyle bi çözüm buldum
            {
                Touch t = Input.GetTouch(i);
                if (t.phase==TouchPhase.Began)
                {
                     playerPhysics.OnJumping(t);
                }
                else if(t.phase == TouchPhase.Moved)
                {
                    playerMovement.PlayerMove(moveSpeed);
                    if (isGround) //karakter havadaysa koþma animasyonu oynamamasý için kontrol
                    {
                        SetAnimatonStates(PlayerAnimationStates.PlayerRun);
                    }
                }
                ++i;
            }
        }
    }
    #region Physics

    #endregion
    #region Animaton
    protected internal void SetAnimatonStates(PlayerAnimationStates playerAnimation)
    {
        animationController.ChangePlayerAnimation(playerAnimation);
    }
    #endregion
    #region Core
    private void OnGameBegin()
    {
        canMove = true;
    }
    private void OnGameEnded()
    {
        canMove = false;
        SetAnimatonStates(PlayerAnimationStates.PlayerDied);
        playerPhysics.SetRBFreeze(); //Oyun bittiðinde topa çarptýðýnda aldýðý darbeyle uçmamasý ve buga girmemesi için
    }
    #endregion
}
