using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharController : MonoBehaviour
{
    // event �ܺο����� ȣ������ ���ϰ� ���´�?
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

    // event�� �ܺ�Ŭ�������� invoke�� ���� ��ų�� ���� ������ ������ ��ų�� �ִ� �Լ��� ����� �� �� ����.
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

    #region �̵� ����
    //float x, y;
    //public float speed = 7f;
    //void Update()
    //{
    //    x = Input.GetAxisRaw("Horizontal"); // GetAxis -> ó���� ������ ���� (��ȯ���� -1~1�� ����?)
    //    y = Input.GetAxisRaw("Vertical");   // GetAxisRaw -> �׻� ���� �ӵ��� �̵� (��ȯ���� -1, 0, 1)

    //    transform.position += new Vector3(x, y) * speed * Time.deltaTime;
    //}
    #endregion
}
