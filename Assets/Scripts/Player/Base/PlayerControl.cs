using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    #region Move Variable
    public Rigidbody2D RB2;
    public float MoveSpeed { get; set; } = 3f;
    bool isFacingRight = true;
    #endregion

    #region State Variable
    public PlayerStateMachine StateMachine { get; set; }

    public PlayerIdleState IdleState { get; set; }
    public PlayerMoveState MoveState { get; set; }
    public PlayerChargeState ChargeState { get; set; }
    public PlayerDamagedState DamagedState { get; set; }
    public PlayerDeadState DeadState { get; set; }
    #endregion

    #region Animation Variable
    public Animator playerAnimator;
    #endregion

    #region Health Variable
    public float TotalHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Slider healthSlider;
    #endregion

    private void Awake()
    {
        //几个状态的初始化
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine);
        MoveState = new PlayerMoveState(this, StateMachine);
        ChargeState = new PlayerChargeState(this, StateMachine);
        DamagedState = new PlayerDamagedState(this,StateMachine);
        DeadState = new PlayerDeadState(this,StateMachine);

        StateMachine.Initialize(IdleState);

        instance = this;
    }
    public static PlayerControl instance;
    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        RB2 = GetComponent<Rigidbody2D>();
        TotalHealth = 10f;
        CurrentHealth = TotalHealth;

        healthSlider.maxValue = TotalHealth;
        healthSlider.value = CurrentHealth;
    }
    private void Update()
    {
        StateMachine.CurrentState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhisicsUpdate();
        CheckForFacingDir();
    }

    void CheckForFacingDir()
    {
        if(RB2.velocity.x > 0)
            isFacingRight = true;
        else if(RB2.velocity.x < 0)
            isFacingRight = false;
        playerAnimator.SetFloat("Look X", isFacingRight ? 1 : 0);
    }

    public void MovePlayer(Vector3 velicity)
    {
        RB2.velocity = velicity * MoveSpeed;
        playerAnimator.SetFloat("Speed", RB2.velocity.magnitude);
    }

    public void ChangeHealth(float amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - amount, 0, TotalHealth);
        healthSlider.value = CurrentHealth;
    }
}
