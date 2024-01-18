using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    TopDownCharController _controller;

    [SerializeField] Transform projectileSpawnPos;
    Vector2 _aimDirection = Vector2.right;

    public GameObject testPf;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharController>();
    }
    private void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }

    void OnShoot()
    {
        CreateProjectile();
    }
    void CreateProjectile()
    {
        Instantiate(testPf, projectileSpawnPos.position, Quaternion.identity);
    }
}
