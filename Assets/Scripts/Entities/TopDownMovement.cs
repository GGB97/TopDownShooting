using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    TopDownCharController _controller;
    CharStatsHandler _stats;
    Vector2 _moventDirection = Vector2.zero;
    Rigidbody2D _rigidbody;

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
    }

    void Move(Vector2 direction)
    {
        _moventDirection = direction;
    }

    void ApplyMovent(Vector2 direction)
    {
        direction = direction * _stats.CurrentStates.speed;
        _rigidbody.velocity = direction;
    }
}
