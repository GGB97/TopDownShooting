using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownContactEnemyController : TopDownEnemyController
{
    [SerializeField][Range(0, 100f)] float followRange;
    [SerializeField] string targetTag = "Player";
    bool _isCollidingWithTarget;

    [SerializeField] SpriteRenderer charRenderer;

    HealthSystem _healthSystem;
    HealthSystem _collidingTargetHealthSystem;
    TopDownMovement _collidingMovement;

    public object GameObj { get; private set; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _healthSystem = GetComponent<HealthSystem>();
        _healthSystem.OnDamage += OnDamge;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_isCollidingWithTarget)
        {
            ApplyHealthChange();
        }

        Vector2 direction = Vector2.zero;
        if (DistanceToTarget() < followRange)
        {
            direction = DirectionToTarget();
        }

        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void OnDamge()
    {
        followRange = 100f;
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        charRenderer.flipX = Mathf.Abs(rotZ) > 90f; // z축 회전
    }

    private void OnTriggerEnter2D(Collider2D collision) // 트리거는 화살밖에 없는데?
    {
        GameObject receiver = collision.gameObject;

        if (!receiver.CompareTag(targetTag))
        {
            return;
        }

        _collidingTargetHealthSystem = receiver.GetComponent<HealthSystem>();
        if(_collidingTargetHealthSystem != null)
        {
            _isCollidingWithTarget = true;
        }

        _collidingMovement = receiver.GetComponent<TopDownMovement>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(targetTag))
        {
            return;
        }

        _isCollidingWithTarget = false;
    }

    void ApplyHealthChange()
    {
        AttackSO attackSO = Stats.CurrentStats.attackSO;
        bool hasBeenChanged = _collidingTargetHealthSystem.ChangeHealth(-attackSO.power);
        if(attackSO.isOnKnockback && _collidingMovement != null)
        {
            _collidingMovement.ApplyKnockback(transform, attackSO.knockbackPower, attackSO.knockbackTime);
        }
    }
}
