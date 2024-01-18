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
        // 정규화 하는 이유 -> wa/wd 와 같은 입력시 벡터값이 높아져서 속도가 달라짐.
        Vector2 moveInput = value.Get<Vector2>().normalized; 
        
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

            // 벡터간의  A - B 를 하면 B->A의 방향벡터가 나옴 그 값을 정규화

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
