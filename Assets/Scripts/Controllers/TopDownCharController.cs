using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharController : MonoBehaviour
{
    // event 외부에서는 호출하지 못하게 막는다?
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    float _timeSinceLastAttact = float.MaxValue;
    protected bool isAttacking {  get; set; }

    protected CharStatsHandler Stats {  get; private set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<CharStatsHandler>();
    }
    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    void HandleAttackDelay()
    {
        if (Stats.CurrentStats.attackSO == null)
            return;

        if (_timeSinceLastAttact <= Stats.CurrentStats.attackSO.delay)
        {
            _timeSinceLastAttact += Time.deltaTime;
        }
        if(isAttacking && _timeSinceLastAttact > Stats.CurrentStats.attackSO.delay)
        {
            _timeSinceLastAttact = 0f;
            CallAttackEvent(Stats.CurrentStats.attackSO);
        }
    }

    // event는 외부클래스에서 invoke를 실행 시킬수 없기 때문에 실행을 시킬수 있는 함수를 만들어 둔 것 같음.
    public void CallMoveEvent(Vector2 direction)
    {
       OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }

    #region 이동 연습
    //float x, y;
    //public float speed = 7f;
    //void Update()
    //{
    //    x = Input.GetAxisRaw("Horizontal"); // GetAxis -> 처음엔 느리게 시작 (반환값이 -1~1의 범위?)
    //    y = Input.GetAxisRaw("Vertical");   // GetAxisRaw -> 항상 같은 속도로 이동 (반환값이 -1, 0, 1)

    //    transform.position += new Vector3(x, y) * speed * Time.deltaTime;
    //}
    #endregion
}
