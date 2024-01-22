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

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector2 direction = Vector2.zero;
        if(DistanceToTarget() < followRange)
        {
            direction = DirectionToTarget();
        }

        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        charRenderer.flipX = Mathf.Abs(rotZ) > 90f; // z√‡ »∏¿¸
    }
}
