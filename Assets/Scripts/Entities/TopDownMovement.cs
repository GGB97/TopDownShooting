using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    TopDownCharController _controller;
    CharStatsHandler _stats;

    Vector2 _moventDirection = Vector2.zero;
    Rigidbody2D _rigidbody;

    Vector2 _knockback = Vector2.zero;
    float knockbackDuration = 0;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharController>();
        _stats = GetComponent<CharStatsHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovent(_moventDirection);
        if(knockbackDuration > 0)
        {
            knockbackDuration -= Time.fixedDeltaTime; // Time.deltaTime -> 이건 Update 문에서 사용
        }                                             // FixedUpdate 에서는 Time.fixedDeltaTime 사용

    }
    
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        _knockback = -(other.position - transform.position).normalized * power; // 넉백 방향
    }

    void Move(Vector2 direction)
    {
        _moventDirection = direction;
    }

    void ApplyMovent(Vector2 direction)
    {
        direction = direction * _stats.CurrentStats.speed;
        if(knockbackDuration > 0)
        {
            direction += _knockback;
        }
        _rigidbody.velocity = direction;
    }
}
