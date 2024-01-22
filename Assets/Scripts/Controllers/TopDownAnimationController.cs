using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : TopDownAnimations
{
    // StringToHash -> 문자열을 int값으로 변환
    // 변환 하는 이유 -> 문자열 비교연산이 시간을 많이 잡아 먹어서. 숫자 비교로 진행 하려고
    static readonly int IsWalking = Animator.StringToHash("IsWalking");
    static readonly int Attack = Animator.StringToHash("Attack");
    static readonly int IsHit = Animator.StringToHash("IsHit");

    HealthSystem _healthSystem;

    protected override void Awake()
    {
        base.Awake();
        _healthSystem = GetComponent<HealthSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.OnAttackEvent += Attacking;
        controller.OnMoveEvent += Move;

        if(_healthSystem != null)
        {
            _healthSystem.OnDamage += Hit;
            _healthSystem.OnInvincibilityEnd += InvincibilityEnd;
        }
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > .5f);
    }

    private void Attacking(AttackSO sO)
    {
        animator.SetTrigger(Attack);
    }
    private void Hit()
    {
        animator.SetBool(IsHit, true);
    }
    private void InvincibilityEnd()
    {
        animator.SetBool(IsHit, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
