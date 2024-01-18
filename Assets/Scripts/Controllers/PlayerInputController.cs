using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharController
{
    Camera _camera;
    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        // ����ȭ �ϴ� ���� -> wa/wd �� ���� �Է½� ���Ͱ��� �������� �ӵ��� �޶���.
        Vector2 moveInput = value.Get<Vector2>().normalized; 
        
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

            // ���Ͱ���  A - B �� �ϸ� B->A�� ���⺤�Ͱ� ���� �� ���� ����ȭ

        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }
    public void OnFire(InputValue value)
    {
        isAttacking = value.isPressed;
    }
}
