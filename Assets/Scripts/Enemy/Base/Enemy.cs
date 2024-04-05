using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    public float damage;
    public float attackArea;
    public TimerHelp AttackCD { get; set; }

    #region 受击相关
    public float knockBackTime = 0.5f;
    private float knockBackCounter;
    #endregion
    #region 生命值属性
    [field: SerializeField] public float MaxHealth { get; set; }
    [field: SerializeField] public float CurrentHealth { get; set; }
    #endregion

    #region 运动相关
    [field: SerializeField] public float Speed { set; get; } = 5f;

    public Transform playerTrans;
    public Rigidbody2D RB { get; set; }
    public Vector3 Direction { get; set; } = Vector3.right;
    public Vector3 Dir { get; set; } = Vector3.right;
    public float MoveSpeed { get; set; }
    #endregion

    #region 动画相关
    public Animator enemyAnimator;
    public AnimationClip attackAnima;
    #endregion

    #region State Machine Variable
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyDeadState DeadState { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyKnockBackState KnockBackState { get; set; }

    #endregion

    #region 状态切换变量
    public bool IsAttackable { get; set; }
    #endregion



    protected virtual void Awake()
    {
        StateMachine = new EnemyStateMachine();
        
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
        DeadState = new EnemyDeadState(this, StateMachine);
        IdleState = new EnemyIdleState(this, StateMachine);
        KnockBackState = new EnemyKnockBackState(this, StateMachine);
        
        StateMachine.Initialize(ChaseState);
    }

    protected void Start()
    {
        //获取刚体组件
        RB = GetComponent<Rigidbody2D>();
        //血量设置
        CurrentHealth = MaxHealth;
        //动画组件
        enemyAnimator = GetComponent<Animator>();

        playerTrans = PlayerControl.instance.transform;
    }

    protected virtual void Update()
    {
        StateMachine.CurrentState.FrameUpdate();
        
    }

    protected void FixedUpdate()
    {
        StateMachine.CurrentState.PhisicsUpdate();
    }


    #region 生命值/死亡 函数
    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        DamageNumberController.instance.SpawnDamage(damageAmount,transform.position);
        if (CurrentHealth <= 0f)
        {
            StateMachine.ChangeState(DeadState);
        }
    }
    public void Damage(float damageAmount, bool shouldKnockBack)
    {
        Damage(damageAmount);
        if(shouldKnockBack)
        {
            Direction.Normalize();
            StateMachine.ChangeState(KnockBackState);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    #endregion

    #region 移动 函数
    public void MoveEnemy(Vector3 velocity)
    {
        RB.velocity = velocity *Speed;
    }

    public void CheckForFacingDirection(Vector3 velocity)
    {
        enemyAnimator.SetFloat("Look X", velocity.x);
        enemyAnimator.SetFloat("Look Y", velocity.y);
    }
    #endregion

    #region 动画事件
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        if (StateMachine.CurrentState != null)
            StateMachine.CurrentState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        EnemyDead,
        EnemyMove,
        EnemyAttack
    }
    #endregion

    #region 攻击距离判定
    public void SetAttackableStatus(bool isAttackable)
    {
        IsAttackable = isAttackable;
    }

    #endregion

}
