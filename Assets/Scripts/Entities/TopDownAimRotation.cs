using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] SpriteRenderer armRenderer;
    [SerializeField] Transform armPivot;

    [SerializeField] SpriteRenderer charRenderer;

    TopDownCharController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharController>();
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDiredction)
    {
        RotateArm(newAimDiredction);
    }

    void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        charRenderer.flipX = armRenderer.flipY;
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
