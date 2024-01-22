using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownRangeEnemyController : TopDownEnemyController
{
    [SerializeField][Range(0, 100f)] float followRange = 15f;
    [SerializeField][Range(0, 10f)] float shootRange = 10f;

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

        float distance = DistanceToTarget();
        Vector2 direction = DirectionToTarget();

        isAttacking = false;
        if (distance <= followRange)
        {
            if (distance <= shootRange) // 사거리 이내에 있으면
            {
                int layerMaskTarget = Stats.CurrentStates.attackSO.target;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 11f,
                    (1 << LayerMask.NameToLayer("Level")) | layerMaskTarget);

                if (hit.collider != null && layerMaskTarget == (layerMaskTarget | (1 << hit.collider.gameObject.layer)))
                {
                    CallLookEvent(direction);    // player 방향 쳐다보고
                    CallMoveEvent(Vector2.zero); // 추적은 하지 않고
                    isAttacking = true;          // 공격
                }
                else
                {
                    CallMoveEvent(direction);
                }
            }
            else
            {
                CallMoveEvent(direction);
            }
        }
        else
        {
            CallMoveEvent(direction); // follow보다 멀면 멈춰야 하지 않나?
        }
    }
}
