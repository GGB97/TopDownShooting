using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : TopDownAnimations
{
    // StringToHash -> ���ڿ��� int������ ��ȯ
    // ��ȯ �ϴ� ���� -> ���ڿ� �񱳿����� �ð��� ���� ��� �Ծ. ���� �񱳷� ���� �Ϸ���
    static readonly int IsWalking = Animator.StringToHash("IsWalking");
    static readonly int Attack = Animator.StringToHash("Attack");
    static readonly int IsHit = Animator.StringToHash("IsHit");

    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.OnAttackEvent += Attacking;
        controller.OnMoveEvent += Move;
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
